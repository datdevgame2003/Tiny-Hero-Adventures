using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;
    private HealthManage healthBar;
    [SerializeField]
    GameObject HitEffectPrefab, ExplosionPrefab;
    [SerializeField] private AudioClip hitSound;
    private AudioSource audioSource;
    public bool isInvincible = false;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
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
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
            PlayerManager.isGameOver = true;
            AudioManager.instance.Play("GameOver");
            Time.timeScale = 0;

        }
    }



    private void Die()
    {
        Debug.Log("Player is died!");
    
       

    }
    private void PlayHitSound()
    {
        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }

}
