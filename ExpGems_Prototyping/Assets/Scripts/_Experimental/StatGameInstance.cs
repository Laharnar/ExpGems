using System;
using UnityEngine;

[System.Serializable]
public class StatGameInstance {

    [SerializeField] private string statName;
    [SerializeField] private string tag;
    [SerializeField] private object value;
    [SerializeField] private float fnum;
    [SerializeField] private int num;
    [SerializeField] private bool tf;

    public StatGameInstance(Stat stat)
    {
        CopyFrom(stat);
    }

    public void CopyFrom(Stat stat)
    {
        this.statName = Stat.GetName(stat);
        this.tag = Stat.GetTag(stat);
        this.value = Stat.GetValue(stat);
        this.fnum = Stat.GetFloat(stat);
        this.num = Stat.GetInt(stat);
        this.tf = Stat.GetBool(stat);
    }

    internal static void AddInt(StatGameInstance stat, int amount)
    {
        stat.num += amount;
    }

    internal int GetInt()
    {
        return num;
    }

    internal void SetInt(int expLeft)
    {
        num = expLeft;
    }
}
