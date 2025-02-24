using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
   
    private void Start()
    {
        currentHealth = maxHealth; 

    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy is attacked! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
           

        }
    }

    private void Die()
    {
        Debug.Log("Enemy is died!");
        gameObject.SetActive(false); // an enemy khong huy

        // tra enemy ve pool
        EnemyPool.Instance.ReleaseEnemy(GetComponent<Enemy>());
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
