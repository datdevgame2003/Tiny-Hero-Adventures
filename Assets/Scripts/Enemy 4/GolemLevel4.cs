using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GolemLevel4 : MonoBehaviour
{
    GameObject target;
    public int enemyHP = 90;
    public Transform borderCheck;
    public Animator animator;
    [SerializeField]
    GameObject HitEffectPrefab;
    public Slider enemyHealthBar;

    void Start()
    {
        enemyHealthBar.maxValue = enemyHP;
        enemyHealthBar.value = enemyHP;


        target = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    void FixedUpdate()
    {

        if (target.transform.position.x > transform.position.x)
            transform.localScale = new Vector2(1f, 1f);
        else
            transform.localScale = new Vector2(-1f, 1f);

    }
    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        enemyHealthBar.value = enemyHP;
        if (enemyHP > 0)
        {
            animator.SetTrigger("damage");
            Vector3 effectOffset = new Vector3(0, 1f, 0);
            GameObject ex = Instantiate(HitEffectPrefab, transform.position + effectOffset, Quaternion.identity);
            
        }
        else
        {
            //play death animation for enemy
            StartCoroutine(Die());
            this.enabled = false;

        }
    }
    IEnumerator Die()
    {
        animator.SetTrigger("dead");
        GetComponent<CapsuleCollider2D>().enabled = false;
        enemyHealthBar.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    public void PlayerDamage()
    {


        target.GetComponent<PlayerHealth>().TakeDamage(20);

    }
}

