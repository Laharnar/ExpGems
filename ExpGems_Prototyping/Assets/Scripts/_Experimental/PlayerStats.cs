using System;
using UnityEngine;

public class PlayerStats : ChildBehaviour {

    [SerializeField] int health = 100;

    [SerializeField] Stat[] stats;

    protected override void InternalInit()
    {
        base.InternalInit();

        SetSpeed();
    }

    public void DoDamage(int value)
    {
        health -= value;

        if (health <= 0)
        {
            GetUnitKill().KillUnit(this);
        }
    }

    public void DoDamage(Stat value)
    {
        DoDamage(Stat.GetInt(value));
    }

    void SetSpeed()
    {
        Stat speed = Stat.GetStatByTag("Speed", stats);
        PlayerMovement move = GetPlayerMovement();
        move.SetSpeed(speed);
    }


    protected void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            DoDamage(30);
        }
    }
}
