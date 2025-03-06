using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    SpriteRenderer spriteRendererComponent;
    private Rigidbody2D rb;
    GameObject playerOJ;
    public float moveSpeed;
    private EnemyHealth enemyHealth;
    
   void Awake()
    {
        spriteRendererComponent = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerOJ = GameObject.FindGameObjectWithTag("Player");
        enemyHealth = GetComponent<EnemyHealth>();
    }
  void Start()
    {
        StartCoroutine(ChasePlayer());
    }

 IEnumerator ChasePlayer()
    {
        Vector2 DirectionToPlayer = Direction2Points2D(this.transform.position, playerOJ.transform.position);
        rb.velocity = DirectionToPlayer * moveSpeed;
        if (DirectionToPlayer.x > 0)
            spriteRendererComponent.flipX = true; // Hướng sang phải
        else if (DirectionToPlayer.x < 0)
            spriteRendererComponent.flipX = false;
        yield return new WaitForSeconds(1);
        StartCoroutine(ChasePlayer());
    }
    Vector2 Direction2Points2D(Vector2 Point1, Vector2 Point2) // Start from Point1
    {
        var Direction2D = Point2 - Point1;
        return Direction2D.normalized;
    }

    public void TakeDamage(int damage)
    {
        enemyHealth.TakeDamage(damage);
    }
    private void OnEnable()
    {
        if (enemyHealth != null)
        {
            enemyHealth.ResetHealth(); // Reset health when spawn again
        }
    }
}
