using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirleTrap : MonoBehaviour
{
    public float rotationSpeed = 4f;
    public float moveSpeed = 4f;
    public Transform pointA;
    public Transform pointB;
    private Vector3 targetPoint;
    private int damage = 5;
    private void Start()
    {
        targetPoint = pointA.position;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            if (transform.position == pointA.position)
            {
                targetPoint = pointB.position;
            }
            else
            {
                targetPoint = pointA.position;
            }
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
     
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
              
                playerHealth.TakeDamage(damage);

            }
        }
    }
}
