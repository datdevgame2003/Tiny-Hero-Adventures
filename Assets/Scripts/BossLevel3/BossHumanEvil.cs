using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BossHumanEvil : MonoBehaviour
{
    GameObject target;
    public float bossHP = 400;
    public Transform borderCheck;
    public Animator animator;
    [SerializeField]
    GameObject HitEffectPrefab;
    public Slider bossHealthBar;
    void Start()
    {
        bossHealthBar.maxValue = bossHP;
        bossHealthBar.value = bossHP;
        target = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    void FixedUpdate()
    {
        if (target == null) return;


        if (target.transform.position.x > transform.position.x)
            transform.localScale = new Vector2(5f, 5f);
        else
            transform.localScale = new Vector2(-5f, 5f);

    }
    public void TakeDamage(int damageAmount)
    {
        bossHP -= damageAmount;
        bossHealthBar.value = bossHP;
        if (bossHP > 0)
        {
            animator.SetTrigger("damage");
            Vector3 effectOffset = new Vector3(0, 1f, 0);
            GameObject ex = Instantiate(HitEffectPrefab, transform.position + effectOffset, Quaternion.identity);
            animator.SetBool("isChasing", true);
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
        yield return new WaitForSeconds(2f); 
        Destroy(gameObject);
        AudioManager.instance.Play("LevelCompleted");
        UnlockNewLevel();
        SceneController.instance.NextLevel();
    }
    public void PlayerDamage()
    {
        target.GetComponent<PlayerHealth>().TakeDamage(20);
        // playerHealth.TakeDamage(15);
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(15);
    }
    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
