using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    private HealthManage healthBar;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<HealthManage>();
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }
    private void OnEnable()
    {
        ResetHealth();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy is attacked! Current health: " + currentHealth);
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
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
        if (healthBar != null)
        {
            healthBar.SetHealth(maxHealth);
        }
    }
}
