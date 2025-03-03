using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    public Transform _allowJump;
    private bool allowJump;
    private bool doubleJump;
    public LayerMask ground;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
   
    private void Start()
    {
       
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //PlayerUI.instance.jumpButton.onClick.AddListener(Jump);
    }

    private void FixedUpdate()
    {
        //float horizontalInput = PlayerUI.instance.joystick.Horizontal;
        allowJump = Physics2D.OverlapCircle(_allowJump.position, 0.2f,ground);
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (allowJump && !Input.GetKey(KeyCode.Space))
        {
            doubleJump = false;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
          if(allowJump || doubleJump)
            {
                body.velocity = new Vector2(body.velocity.x, jumpForce);
                doubleJump = !doubleJump;
            }
        }

        //flip
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4);

        //set animator parameter
        anim.SetBool("run", horizontalInput != 0);
      
    }
  

    //private void Jump()
    //{
    //    if (grounded)
    //    {
    //        body.velocity = new Vector2(body.velocity.x, jumpForce);
    //        anim.SetTrigger("jump");
    //        grounded = false;
    //    }
    //}

}
