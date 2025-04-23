using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform _allowJump;
    private bool allowJump;
    private bool doubleJump;
    public LayerMask ground;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private float velocityX;
    public float smoothTime = 0.05f;
    private void Start()
    {
       
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PlayerUI.instance.jumpButton.onClick.AddListener(Jump);
    }

    private void FixedUpdate()
    {
        float horizontalInput = PlayerUI.instance.joystick.Horizontal;
        if (Mathf.Abs(horizontalInput) < 0.05f)
            horizontalInput = 0;

        float targetVelocityX = horizontalInput * speed;

        // Làm mượt di chuyển
        velocityX = Mathf.SmoothDamp(body.velocity.x, targetVelocityX, ref velocityX, smoothTime);
        body.velocity = new Vector2(velocityX, body.velocity.y);
        allowJump = Physics2D.OverlapCircle(_allowJump.position, 0.2f,ground);
        //float horizontalInput = Input.GetAxis("Horizontal");
      //  body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (allowJump)
        {
            doubleJump = false;
        }
        
        //flip
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4);

        //set animator parameter
        anim.SetBool("run", horizontalInput != 0);
      
    }


    private void Jump()
    {
        if (allowJump || !doubleJump)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            //anim.SetTrigger("jump");
            doubleJump = !doubleJump;
            //grounded = false;
        }
    }

}
