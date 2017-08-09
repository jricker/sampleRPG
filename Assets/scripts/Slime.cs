using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy
{

    public float maxHealth, power, toughness;
    public float currentHealth;



    public void PerformAttack()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            Debug.Log(currentHealth);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}