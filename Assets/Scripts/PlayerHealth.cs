using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int currentHealth = 100;
    private HealthManage healthBar;
    [SerializeField]
    GameObject HitEffectPrefab, ExplosionPrefab;
    [SerializeField] private AudioClip hitSound;
    private AudioSource audioSource;
 
    private void Start()
    {
      
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<HealthManage>();
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
       
        PlayHitSound();
        Vector3 effectOffset = new Vector3(0, 0.5f, 0);
        GameObject hit = Instantiate(HitEffectPrefab, transform.position + effectOffset, Quaternion.identity);
        healthBar.SetHealth(currentHealth);
        Debug.Log("Player is attacked! Current health: " + currentHealth);
        if (currentHealth == 0)
        {
            Die();


        }
    }
    private void Die()
    {
        Debug.Log("Player is died!");
        gameObject.SetActive(false); // an enemy khong huy
        Vector3 effectOffset = new Vector3(0, 1f, 0);
        GameObject ex = Instantiate(ExplosionPrefab, transform.position + effectOffset, Quaternion.identity);
    }
    private void PlayHitSound()
    {
        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }

}
