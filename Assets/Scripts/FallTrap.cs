using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrap : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFalling = false;
    public Transform restorePoint;
    public int damageFallTrap = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.CompareTag("Player") && !isFalling)
        {
            rb.isKinematic = false;
            isFalling = true;
            Invoke("RestoreThorn", 1.5f);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                
                playerHealth.TakeDamage(damageFallTrap);

            }
        }
    }

    private void RestoreThorn()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.angularDrag = 0;
        transform.position = restorePoint.position;
        isFalling = false;
    }

}
