using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
   private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.J)) 
        {
            anim.SetTrigger("attack");
        }
    }
}
