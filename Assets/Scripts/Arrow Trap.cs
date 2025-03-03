using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Vector2 initialPosition; 
    private Rigidbody2D rb;
    private int damage= 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; 
    }

    void Update()
    {
       
        if (transform.position.y == -5.8f) 
        {
            ResetArrow();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground") 
        {
            ResetArrow();
        }
       else if(collision.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if(playerHealth != null)
            {
                ResetArrow();
                playerHealth.TakeDamage(damage);
             
            }
        }
    }

   private void ResetArrow()
    {
        transform.position = initialPosition; 
        rb.velocity = Vector2.zero; 
    }
}


