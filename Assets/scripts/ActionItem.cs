using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionItem : Interactable {

    public override void Interact()
    {
        Debug.Log("interacting with base action item");
    }
}