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
    Player playerObject;
    //GameObject player;

    private void Start()
    {
        playerObject = GetComponent<Player>();
        //spawnProjectile = player.transform.Find("ProjectileSpawn");
        spawnProjectile = transform.Find("ProjectileSpawn");
        characterStats = playerObject.characterStats;
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
            Debug.Log("not a projectile weapon");
        }

        equippedWeapon.Stats = itemToEquip.Stats;//  (itemToEquip.Stats);
        EquippedWeapon.transform.SetParent(playerHand.transform);
        playerObject.characterStats.AddStatBonus(itemToEquip.Stats);
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