//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FireController : MonoBehaviour
//{
//    [SerializeField] public float moveSpeed = 5f;

//    private Vector2 direction;

//    void Update()
//    {
//        transform.Translate(direction * moveSpeed * Time.deltaTime); //ban theo huong di chuyen 
//    }

//    public void SetDirection(Vector2 newDirection)
//    {
//        direction = newDirection;
//    }
//    private void OnTriggerEnter2D(Collider2D other)
//    {

//        if (other.CompareTag("Enemy"))
//        {

//            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
//            if (enemyHealth != null)
//            {
//                enemyHealth.TakeDamage(10);
//            }


//            Destroy(gameObject);
//        }
//    }

//}
