using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitKill : MonoBehaviour {
    static UnitKill instance;

    public delegate IEnumerator AfterUnitDeath();
    List<AfterUnitDeath> afterDeath = new List<AfterUnitDeath>();


    private void Awake()
    {
        instance = this;
    }

    public static void KillUnit(PlayerStats unit)
    {
        instance.StartCoroutine(instance.CKillUnit(unit));
    }

    internal void AfterKillDo(AfterUnitDeath fun)
    {
        Debug.Log("Registering one function to after death.");
        afterDeath.Add(fun);
    }

    private IEnumerator CKillUnit(PlayerStats unit)
    {
        Destroy(unit.UseParentAsRoot ? unit.transform.parent.gameObject : unit.gameObject);

        // activate the rest of after death stuff... ui, drops, etc.
        for (int i = 0; i < afterDeath.Count; i++)
        {
            QuickLog.Msg("Triggering after death.");
            yield return StartCoroutine(afterDeath[i]());
        }

        Debug.Log("After death coro working.");
        yield break;
    }
    
}


