using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State { Idle,Run,Attack }
    private State currentState = State.Idle;
    SpriteRenderer spriteRenderer;
    private Animator anim;
    private Rigidbody2D rb;
    public Transform player;
    public float detectionRange = 4f; 
    public float attackRange = 1f;
    public float moveSpeed;
  
    private EnemyHealth enemyHealth;
    private Vector3 startPosition;
    public int enemyDamage = 5;
    //private float attackCooldown = 1.5f; 
    //private float lastAttackTime;
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
                anim.SetBool("isRunning", false);
                anim.SetBool("isAttacking", false);
                if (isPlayerInDetectionRange && !isPlayerInAttackRange)
                {
                    ChangeState(State.Attack);
                }
                break;

            case State.Run:
                anim.SetBool("isRunning", true);
                anim.SetBool("isAttacking", false);
                FlipDirection();
                MoveTowards();

                if (isPlayerInAttackRange)
                {
                    ChangeState(State.Idle);
                    Invoke(nameof(StartAttack), 0.1f);
                }
                break;
            case State.Attack:
                anim.SetBool("isRunning", false);
                anim.SetBool("isAttacking", true);  
                FlipDirection();
               
                if (!isPlayerInAttackRange)
                    ChangeState(State.Run);
                break;
        }
    }
    void FlipDirection()
    {
        if (player == null) return;

       
        spriteRenderer.flipX = player.position.x > transform.position.x;
    }
    void StartAttack()
    {
        if (currentState == State.Idle) 
        {
            ChangeState(State.Attack);
        }
    }

    void ChangeState(State newState)
    {
        currentState = newState;
       
    }

    void MoveTowards()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        FlipDirection();

    }
     
        void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ChangeState(State.Idle);
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {

                playerHealth.TakeDamage(enemyDamage);

            }
            Invoke(nameof(StartAttack), 0.1f);
           
        }
    }

    void OnTriggerExit2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
            ChangeState(State.Run);


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