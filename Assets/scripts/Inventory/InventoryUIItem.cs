using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour {
    public Item item;
    public Text itemText;
    public Image itemImage;

    public void SetItem(Item item)
    {
        this.item = item;
        setupItemValues();
    }

    void setupItemValues()
    {
        itemText.text = item.ItemName;
        itemImage.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
        //this.transform.Find("Item_Name").GetComponent<Text>().text = item.ItemName;
        //this.transform.Find("Item_Icon").GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
    }
    public void OnSelectItemButton()
    {
        Debug.Log("hey it worked");
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
    }

}