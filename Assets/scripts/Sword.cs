using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon {
    public List<BaseStat> Stats { get; set; }
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Base_Attack");
        //Debug.Log(this.name + " Attack!");
    }

    public void SpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
        //Debug.Log(this.name + " Attack!");
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
        }
    }

}
