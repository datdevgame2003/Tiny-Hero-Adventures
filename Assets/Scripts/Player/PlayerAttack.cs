﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float attackRange = 1.5f; 
    [SerializeField] private int attackDamage = 10; 
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Transform attackPoint;
    private bool canAttack = true;
    [SerializeField] private AudioClip attackSound;
    private AudioSource audioSource;
    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        PlayerUI.instance.attackButton.onClick.AddListener(() => {
            if (canAttack) StartCoroutine(Attack());
        });
    }
   
    private IEnumerator Attack()
    {
        canAttack = false; //  ko spam attack
        anim.SetTrigger("attack");
        if (attackSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(attackSound);
        }
        yield return new WaitForSeconds(0.1f); // Cho animation attack

        // Kiem tra enemy trong vung attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {

                enemy.GetComponent<Golem>()?.TakeDamage(attackDamage);
                enemy.GetComponent<BossLevel1>()?.TakeDamage(attackDamage);
                enemy.GetComponent<BossLevel2>()?.TakeDamage(attackDamage);
                enemy.GetComponent<BossHumanEvil>()?.TakeDamage(attackDamage);
                enemy.GetComponent<GolemFrozen>()?.TakeDamage(attackDamage);
                enemy.GetComponent<BossFire>()?.TakeDamage(attackDamage);
                enemy.GetComponent<GolemLevel4>()?.TakeDamage(attackDamage);
            }
        }

        yield return new WaitForSeconds(attackCooldown); // Cho tg attack
        canAttack = true; // duoc đanh tiep
    }
  
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
