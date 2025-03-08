using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State { Idle,Attack }
    private State currentState = State.Idle;
    SpriteRenderer spriteRenderer;
    private Animator anim;
    private Rigidbody2D rb;
    public Transform player;
    public float detectionRange = 4f; // Khoảng cách phát hiện Player
    public float attackRange = 1f;
    public float moveSpeed;
    private EnemyHealth enemyHealth;
    private Vector3 startPosition;
    public int enemyDamage = 5;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        bool isPlayerInAttackRange = distanceToPlayer < attackRange;
        bool isPlayerInDetectionRange = distanceToPlayer < detectionRange;
      
        switch (currentState)
        {
            case State.Idle:
                anim.SetBool("isAttacking", false);
                if (isPlayerInDetectionRange && isPlayerInAttackRange)
                {
                    ChangeState(State.Attack);
                }
                break;

            case State.Attack:
               
                anim.SetBool("isAttacking", true);
                FlipDirection();
                if (!isPlayerInAttackRange)
                    ChangeState(State.Idle);
                break;
        }
    }
    void FlipDirection()
    {
        if (player == null) return;

        // Nếu Player ở bên trái, flipX = true, nếu ở bên phải, flipX = false
        spriteRenderer.flipX = player.position.x > transform.position.x;
    }

   
    void ChangeState(State newState)
    {
        currentState = newState;
        //switch (newState)
        //{
        //    case State.Idle:
        //        anim.SetBool("isRunning", false);
        //        anim.SetBool("isAttacking", false);
        //        break;
        //    case State.Run:
        //        anim.SetBool("isRunning", true);
        //        anim.SetBool("isAttacking", false);
        //        break;
        //    case State.Attack:
        //        anim.SetBool("isRunning", false);
        //        anim.SetBool("isAttacking", true);
        //        break;
        //}
    }

    //void MoveTowardsPlayer()
    //{
    //    Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
    //    transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);


    //}

    //void ReturnToStart()
    //{
    //    Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
    //    if (Vector2.Distance(transform.position, startPosition) > 0.1f)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    //    }
    //    else
    //    {
    //        // Khi đến nơi, dừng lại và chuyển về trạng thái Idle
    //        transform.position = startPosition;
    //        ChangeState(State.Idle);
    //    }
    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ChangeState(State.Attack);
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
               
                playerHealth.TakeDamage(enemyDamage);

            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        ChangeState(State.Idle);
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