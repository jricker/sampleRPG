using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon {
    private Animator animator;
    public List<BaseStat> Stats { get; set; }
    public CharacterStats CharacterStats { get; set; }

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
            //col.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
            //col.GetComponent<IEnemy>().TakeDamage(5);
            col.GetComponent<IEnemy>().TakeDamage(CharacterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue());
        }
    }

}
