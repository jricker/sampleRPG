using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }
    public GameObject player;
    //public GameObject projectileSpawn;

    Transform spawnProjectile;
    IWeapon equippedWeapon;

    CharacterStats characterStats;

    private void Start()
    {
        player = GameObject.Find("Cube").gameObject;
        spawnProjectile = player.transform.Find("ProjectileSpawn");
        //spawnProjectile = projectileSpawn.transform;
        characterStats = GetComponent<CharacterStats>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }


        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();

        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }
        else
        {
            Debug.Log("nothing is showing in projectile weapon");
        }

        equippedWeapon.Stats = itemToEquip.Stats;//  (itemToEquip.Stats);
        EquippedWeapon.transform.SetParent(playerHand.transform);
        characterStats.AddStatBonus(itemToEquip.Stats);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PerformWeaponAttack();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            PerformSpecialWeaponAttack();
        }
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack();
    }
    public void PerformSpecialWeaponAttack()
    {
        equippedWeapon.SpecialAttack();
    }
}