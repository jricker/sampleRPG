using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable {
    public void Consume()
    {
        Debug.Log("you drank a swig of the potion, cool!");
        //throw new NotImplementedException();
    }

    public void Consume(CharacterStats stats)
    {
        Debug.Log("you drank a swig of the potion, RAD!");
        //throw new NotImplementedException();
    }


}
