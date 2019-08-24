using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class GemV2 {
    // intial setup
    [SerializeField] ExperienceAttribute attributeData;

    // instance
    [SerializeField] ExperienceAttributeInstance expInstance;

    public void Init()
    {
        expInstance = ExperienceAttributeInstance.New(attributeData);
    }

    int ApplyLevelingFormula(int amount)
    {
        int currentLevel = expInstance.CurrentLevel;
        float lowerLimit = 1f + amount * 0.9f;
        float upperLimit = 1f + amount * 1.1f * (1f + currentLevel / 100);
        return (int)UnityEngine.Random.Range(lowerLimit, upperLimit);
    }

    public void RecieveExp(int amount)
    {
        amount = ApplyLevelingFormula(amount);
        Debug.Log("Recieved exp: " + amount);
        expInstance.GainExp(amount, attributeData);
    }

}

public class Gems : MonoBehaviour {
    static Gems instance;

    // intial setup
    [SerializeField] GemV2 gemPlayerExp;

    [SerializeField] Stat[] gemExperienceData;

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

        // init new
        gemPlayerExp.Init();

        // init old
        experienceInstance = new StatGameInstance[gemExperienceData.Length];
        for (int i = 0; i < gemExperienceData.Length; i++)
        {
            experienceInstance[i] = new StatGameInstance(gemExperienceData[i]);
        }
    }

    int ApplyLevelingFormula(int amount)
    {
        int currentLevel = this.currentLevel;
        float lowerLimit = 1f + amount * 0.9f;
        float upperLimit = 1f + amount * 1.1f * (1f + currentLevel / 100);
        return (int)UnityEngine.Random.Range(lowerLimit, upperLimit);
    }



    public void RecieveExp(int gemType, int amount)
    {
        if (gemType < experienceInstance.Length)
        {
            Debug.Log("Recieved exp: " + amount);
            StatGameInstance.AddInt(experienceInstance[gemType], amount);
            currentExp += amount;
        }
        else
        {
            Debug.Log("EXP ERROR: out of range." + gemType + " " + experienceInstance.Length, this);
        }

        if (experienceInstance[gemType].GetInt() >= maxExpForThisLevel)
        {
            currentLevel++;
            Debug.Log("Level up! to level " + currentLevel);

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
            int newMaxExp = (int)(maxExpForThisLevel * (1 + sample));
            maxExpForThisLevel = newMaxExp;
            Debug.Log("percentage : " + percentage + "curve result: " + sample + " multiplier: " + multiplier + " -> " + newMaxExp);

        }
    }

    internal static void GetExpOnAttack()
    {
        GetSomeExp(1, 1);
    }

    internal static void GetSomeExp(int gemType, int amount)
    {
        if (gemType == 0)
        {
            instance.gemPlayerExp.RecieveExp(amount);
        }
        else
        {
            amount = instance.ApplyLevelingFormula(amount);
            instance.RecieveExp(gemType, amount);
        }
    }

}
