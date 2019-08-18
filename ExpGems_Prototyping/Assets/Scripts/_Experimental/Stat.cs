using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Stats/NewStat", order = 1)]
public class Stat:ScriptableObject {

    [SerializeField] public string statName;
    [SerializeField] public string tag;
    protected object value;
    [SerializeField] protected float fnum;
    [SerializeField] protected int num;
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
            return stat.fnum;
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

    internal static object GetValue(Stat stat)
    {
        return stat.value;
    }

    internal static string GetTag(Stat stat)
    {
        return stat.tag;
    }

    internal static string GetName(Stat stat)
    {
        return stat.statName;
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
