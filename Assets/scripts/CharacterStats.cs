using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats {
    
    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStats(int power, int toughness, int attackSpeed)
    {
        stats = new List<BaseStat>()
        {
            new BaseStat(BaseStat.BaseStatType.Power, power, "Powerssssss" ),
            new BaseStat(BaseStat.BaseStatType.Toughness, toughness, "Toughness Defeeeeense" ),
            new BaseStat(BaseStat.BaseStatType.AttackSpeed, attackSpeed, "Attack Speeeeeeed" )
        };
    }
    
    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        Debug.Log("in the ChraacterStats class, GetStat method, Base Stat return");
        return this.stats.Find(x => x.StatType == stat);
    }


    public void AddStatBonus(List<BaseStat> statBonuses)
    {

        foreach (BaseStat statBonus in statBonuses)
        {
            GetStat(statBonus.StatType).AddStatBonus(new StatBonus(statBonus.BaseValue) );
        }
    }


    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {

        foreach (BaseStat statBonus in statBonuses)
        {
            GetStat(statBonus.StatType).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

}