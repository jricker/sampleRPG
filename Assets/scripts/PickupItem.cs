using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable {

    public override void Interact()
    {
        Debug.Log("interacting with Item!");
    }

}