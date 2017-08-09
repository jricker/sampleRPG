using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    public List<BaseStat> Stats { get; set; }

    public Transform ProjectileSpawn { get; set;}

    private Animator animator;
    Fireball fireball;

    void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/fireball"); 
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


    public void CastProjectile()
    {
        //Debug.Log(ProjectileSpawn.position);
        Fireball fireballInstance = (Fireball)Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
        fireballInstance.Direction = transform.forward;

    }
}
