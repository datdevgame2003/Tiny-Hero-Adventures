using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossLevel1 : MonoBehaviour
{
    GameObject target;
    public float enemyHP = 500;
    public Transform borderCheck;
    public Animator animator;
    [SerializeField]
    GameObject HitEffectPrefab;
    public Slider bossHealthBar;
    void Start()
    {
        bossHealthBar.maxValue = enemyHP;
        bossHealthBar.value = enemyHP;
        target = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    void FixedUpdate()
    {
        if (target == null) return;

 
        if (target.transform.position.x > transform.position.x)
            transform.localScale = new Vector2(1f, 1f);
        else
            transform.localScale = new Vector2(-1f, 1f);

    }
    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        bossHealthBar.value = enemyHP;
        if (enemyHP > 0)
        {
            animator.SetTrigger("damage");
            Vector3 effectOffset = new Vector3(0, 1f, 0);
            GameObject ex = Instantiate(HitEffectPrefab, transform.position + effectOffset, Quaternion.identity);
            //animator.SetBool("isChasing", true);
        }
        else
        {
            StartCoroutine(Die());
            this.enabled = false;
        }
    }
    IEnumerator Die()
    {
        animator.SetTrigger("dead");
        GetComponent<CapsuleCollider2D>().enabled = false;
        bossHealthBar.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f); // đợi animation kết thúc
        Destroy(gameObject);
    }
    public void PlayerDamage()
    {
        target.GetComponent<PlayerHealth>().TakeDamage(15);
        // playerHealth.TakeDamage(15);
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(15);
    }
}
