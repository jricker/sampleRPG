﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour{
    public static InventoryController Instance { get; set; }
    public PlayerWeaponController playerWeaponController;
    public ConsumableController consumableController;
    public InventoryUIDetails inventoryDetailsPanel;
    public List<Item> playerItems = new List<Item>();

    private void Start()
    {
        //Instance = this;
        if (Instance != null && Instance != this)
            Destroy(gameObject);
            //Debug.Log("object destroyed in Inventory Controller");
        else
            Instance = this;
        playerWeaponController = GetComponent<PlayerWeaponController>();
        consumableController = GetComponent<ConsumableController>();
        GiveItem("sword");
        GiveItem("potion_log");
        GiveItem("staff");

    }

    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.Instance.GetItem(itemSlug);
        playerItems.Add(item);
        Debug.Log(playerItems.Count + " items in inventory. Added: " + itemSlug);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void SetItemDetails(Item item, Button selectedButton)
    {
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }

    public void EquipItem(Item itemToEquip)
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }

    public void ConsumeItem(Item itemToConsume)
    {
        consumableController.ConsumeItem(itemToConsume);
    }
}