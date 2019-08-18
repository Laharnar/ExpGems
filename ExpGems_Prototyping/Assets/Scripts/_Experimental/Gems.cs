using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : ChildBehaviour
{
    static Gems instance;

    // intial setup
    [SerializeField] Stat[] gemExperienceData;

    // instance
    StatGameInstance[] gemExperienceInstance;

    protected override void Awake()
    {
        instance = this;

        gemExperienceInstance = new StatGameInstance[gemExperienceData.Length];
        for (int i = 0; i < gemExperienceData.Length; i++)
        {

            gemExperienceInstance[i] = new StatGameInstance(gemExperienceData[i]);
        }

        base.Awake();
    }

    public static void TriggerExpGain(int gemType, int amount)
    {
        instance.RecieveExp(gemType, amount);
    }

    public void RecieveExp(int gemType, int amount)
    {
        if (gemType < gemExperienceInstance.Length)
        {
            StatGameInstance.AddInt(gemExperienceInstance[gemType], amount);
        }
    }
}
