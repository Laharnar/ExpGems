using System.Collections;
using UnityEngine;

public class UnitKill : MonoBehaviour {
    static UnitKill instance;

    private void Awake()
    {
        instance = this;
    }

    public static void KillUnit(PlayerStats unit)
    {
        instance.StartCoroutine(instance.CKillUnit(unit));
    }

    private IEnumerator CKillUnit(PlayerStats unit)
    {
        Destroy(unit.UseParentAsRoot ? unit.transform.parent.gameObject : unit.gameObject);
        yield break;
    }
}