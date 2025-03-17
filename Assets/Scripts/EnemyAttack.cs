//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyAttack : MonoBehaviour
//{
//    public int attackDamage = 10; // 🔥 Sát thương của Enemy
//    private Collider2D attackTrigger; // ✅ Collider để phát hiện Player
//    private bool canDealDamage = false; // ⚔ Chỉ gây sát thương khi Attack

//    private void Start()
//    {
//        attackTrigger = GetComponent<Collider2D>(); // Lấy Trigger
//        attackTrigger.enabled = false; // Ban đầu tắt Trigger
//    }

//     🔥 Bật Trigger khi Animation Attack bắt đầu
//    public void EnableAttackTrigger()
//    {
//        attackTrigger.enabled = true;
//        canDealDamage = true;
//    }

//     ❌ Tắt Trigger khi Animation Attack kết thúc
//    public void DisableAttackTrigger()
//    {
//        attackTrigger.enabled = false;
//        canDealDamage = false;
//    }

//    private void /*OnTriggerEnter2D(Collider2D collision)*/
//    {
//        if (canDealDamage && collision.CompareTag("Player"))
//        {
//            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
//            if (playerHealth != null)
//            {
//                playerHealth.TakeDamage(attackDamage); // 🔥 Gây sát thương lên Player
//                Debug.Log("Player bị Enemy tấn công!");
//            }
//        }
//    }
//}
