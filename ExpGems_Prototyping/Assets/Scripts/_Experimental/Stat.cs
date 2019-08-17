using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Stats/NewStat", order = 1)]
public class Stat:ScriptableObject {

    public string name;
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

    public float GetFloat()
    {
        return num;
    }

    public int GetInt()
    {
        return (int)num;
    }

    public bool GetBool()
    {
        return tf;
    }
}
