
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private List<GameObject> paths;
    private int currentIndex = 0;
    private GameObject currentPath;
    public float moveSpeed = 1;
    public float waitTime = 1;
    private EnemyHealth enemyHealth;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    public void SetPath(List<GameObject> newPaths)
    {
        paths = newPaths;
        currentIndex = 0;
        if (paths.Count > 0)
        {
            currentPath = paths[currentIndex];
        }
        StartCoroutine(MoveTo());
    }

    private void ChangeDirection()
    {
        currentIndex = (currentIndex + 1) % paths.Count;
        currentPath = paths[currentIndex];
        StartCoroutine(MoveTo());
    }

    IEnumerator MoveTo()
    {
        rb.velocity = Vector2.zero;
        anim.Play("Enemy Idle");
        yield return new WaitForSeconds(waitTime);

        if (currentPath != null)
        {
            Vector2 direction = (currentPath.transform.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
            RotateToPath(direction);
            anim.Play("Enemy Run");
        }
    }

    private void RotateToPath(Vector2 direction)
    {
        spriteRenderer.flipX = direction.x > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == currentPath)
        {
            ChangeDirection();
        }
      
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
