using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Stats/NewStat", order = 1)]
public class Stat:ScriptableObject {

    public string statName;
    public string tag;
    protected object value;
    [SerializeField] protected float num;
    [SerializeField] protected bool tf;

    public object GetValue()
    {
        return value;
    }
    public void SetValue(object x)
    {
        value = x;
    }

    public static float GetFloat(Stat stat)
    {
        if (stat != null)
            return stat.num;
        Debug.Log("Stat isn't assigned.");
        return 0f;
    }

    public static int GetInt(Stat stat)
    {
        if (stat != null)
            return (int)stat.num;
        Debug.Log("Stat isn't assigned.");
        return 0;
    }

    public static bool GetBool(Stat stat)
    {
        if (stat != null)
            return stat.tf;
        Debug.Log("Stat isn't assigned.");
        return false;
    }


    internal static Stat GetStatByTag(string tag, Stat[] stats)
    {
        for (int i = 0; i < stats.Length; i++)
        {
            if (stats[i].tag.CompareTo(tag) == 0)
            {
                return stats[i];
            }
        }

        QuickLog.Msg("Stat with tag doesn't exist:",tag, "len", stats.Length);
        return null;
    }
}
