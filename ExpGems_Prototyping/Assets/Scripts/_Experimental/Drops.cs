using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : ChildBehaviour
{
    public int gemExpDrop;

    UnitKill onDeath;

    // Start is called before the first frame update
    void Start()
    {
        onDeath = GetUnitKill();
        onDeath.AfterKillDo(DropForPlayer);
    }

    IEnumerator DropForPlayer()
    {
        QuickLog.Msg("Dropping", gemExpDrop);
        Gems.GetSomeExp(0, gemExpDrop);
        yield break;
    }
}
