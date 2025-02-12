using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        PlayerUI.instance.attackButton.onClick.AddListener(Attack);
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
    }


}
