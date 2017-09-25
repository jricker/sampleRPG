using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; set; }
    private List<Item> Items { get; set; }
    // Use this for initialization
    void Awake()
    {
        //Instance = this;
        if (Instance != null && Instance != this)
            Destroy(gameObject);
            //Debug.Log("object destroyed in ItemDatabase");
        else
            Instance = this;
        BuildDatabase();

    }
    public void BuildDatabase()
    {
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
        Debug.Log(Items[0].Stats[1].StatName + " level is " + Items[0].Stats[1].GetCalculatedStatValue());


    }

    public Item GetItem(string itemSlug)
    {
        foreach (Item item in Items)
        {
            if (item.ObjectSlug == itemSlug)
                return item;
        }
        Debug.Log("Warning, couldn't find item " + itemSlug);
        return null;
    }
}