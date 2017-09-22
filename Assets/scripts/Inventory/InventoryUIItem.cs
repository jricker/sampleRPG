using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour {
    public Item item;

    public void SetItem(Item item)
    {
        this.item = item;
        setupItemValues();
    }

    void setupItemValues()
    {
        this.transform.FindChild("Item_Name").GetComponent<Text>().text = item.ItemName;
    }
    public void OnSelectItemButton()
    {
        Debug.Log("hey it worked");
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());

    }

}