using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
    static Gems instance;

    // intial setup
    [SerializeField] Stat[] gemExperienceData;

    // instance
    [SerializeField] StatGameInstance[] experienceInstance;

    [SerializeField] AnimationCurve expLimit;
    [SerializeField] AnimationCurve expIncreasePercentage;
    [SerializeField] int maxLevelX = 80;
    [SerializeField] int maxGlobalExpLimit = 1000000;
    [SerializeField] int maxExpForThisLevel = 10;
    [SerializeField] int currentLevel = 1;
    [SerializeField] int currentExp = 0;


    protected void Awake()
    {
        instance = this;

        experienceInstance = new StatGameInstance[gemExperienceData.Length];
        for (int i = 0; i < gemExperienceData.Length; i++)
        {

            experienceInstance[i] = new StatGameInstance(gemExperienceData[i]);
        }
        
    }

    public static void TriggerExpGain(int gemType, int amount)
    {
        instance.RecieveExp(gemType, instance.ApplyLevelingFormula(amount));
    }

    int ApplyLevelingFormula(int amount)
    {
        return (int)UnityEngine.Random.Range(1f+amount*0.9f, 1f+amount*1.1f * (1f+currentLevel/100));
        
    }

    public void RecieveExp(int gemType, int amount)
    {
        Debug.Log("Recieved exp: "+amount);
        if (gemType < experienceInstance.Length)
        {
            StatGameInstance.AddInt(experienceInstance[gemType], amount);
            currentExp += amount;
        }

        if (experienceInstance[gemType].GetInt() >= maxExpForThisLevel)
        {
            currentLevel++;

            // Add leftover exp to new level.
            int expLeft = experienceInstance[gemType].GetInt() - maxExpForThisLevel;
            experienceInstance[gemType].SetInt(expLeft);
            currentExp = expLeft;

            // Calcualte what the new exprience required for new level is.
            float percentage = (float)currentLevel / (float)maxLevelX;
            //float sample = expLimit.Evaluate(percentage);
            float sample = expIncreasePercentage.Evaluate(percentage);
            //float multiplier = Mathf.Max((int)(sample * maxGlobalExpLimit), 1);
            float multiplier = 1;
            int newMaxExp = (int)(maxExpForThisLevel * (1+ sample));
            maxExpForThisLevel = newMaxExp;
            Debug.Log("percentage : " + percentage + "curve result: " + sample + " multiplier: " + multiplier + " -> " + newMaxExp);

        }
    }

    internal static void TriggerExpGainOnAttack()
    {
        TriggerExpGain(1, 1);
    }
}
