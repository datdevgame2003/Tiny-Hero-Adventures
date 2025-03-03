using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
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
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Player is attacked! Current health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();


        }
    }
    private void Die()
    {
        Debug.Log("Player is died!");
        gameObject.SetActive(false); // an enemy khong huy
    }
   
   
}
