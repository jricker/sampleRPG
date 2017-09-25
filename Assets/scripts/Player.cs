using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CharacterStats characterStats;

    private void Start()
    {
        Debug.Log("should be character stats time.");
        characterStats = new CharacterStats(10,20,30);
        Debug.Log(characterStats.stats[0]);
        //foreach (BaseStat x in characterStats.stats)
        //{
        //    Debug.Log(x.BaseValue);
        //}
    }
}
