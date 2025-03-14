using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    private Animator anim;
    private HealthManage healthBar;
    [SerializeField]
    GameObject HitEffectPrefab, ExplosionPrefab;
    [SerializeField] private AudioClip dieSound;
    private AudioSource audioSource;

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
    }
    private void OnEnable()
    {
        ResetHealth();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Vector3 effectOffset = new Vector3(0, 2f, 0);
        GameObject hit = Instantiate(HitEffectPrefab, transform.position + effectOffset, Quaternion.identity);
        Debug.Log("Enemy is attacked! Current health: " + currentHealth);
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            if (dieSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(dieSound);
            }
            Die();
           

        }
    }

    private void Die()
    {
        Debug.Log("Enemy is died!");

        if (dieSound != null)
        {
            AudioSource.PlayClipAtPoint(dieSound, transform.position);
        }
        Vector3 effectOffset = new Vector3(0, 2f, 0);
        GameObject ex = Instantiate(ExplosionPrefab, transform.position + effectOffset, Quaternion.identity);
        //gameObject.SetActive(false); // an enemy khong huy
        Destroy(gameObject);
        // tra enemy ve pool
        //EnemyPool.Instance.ReleaseEnemy(GetComponent<EnemyAI>());
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetHealth(maxHealth);
        }
    }
    //private void PlayDieSound()
    //{
    //    if (dieSound != null && audioSource != null)
    //    {
    //        audioSource.PlayOneShot(dieSound);
    //    }
    //}
}
