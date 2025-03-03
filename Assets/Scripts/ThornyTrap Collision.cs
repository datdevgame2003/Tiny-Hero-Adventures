using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornyTrapCollision : MonoBehaviour
{
    private int damage = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("Trap hit player");
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
