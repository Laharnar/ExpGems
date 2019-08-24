using UnityEngine;
// TODO: editor for stat -> cover up different types
[System.Serializable]
class ExperienceAttributeInstance {
    //ExperienceAttribute reference;
    [SerializeField] int maxExpForThisLevel = 10;
    [SerializeField] int currentLevel = 1;
    [SerializeField] int currentExp = 0;

    public int MaxExpForThisLevel { get => maxExpForThisLevel; }
    public int CurrentLevel { get => currentLevel; }
    public int CurrentExp {
        get => currentExp; set { currentExp = value; }
    }

    public static ExperienceAttributeInstance New(ExperienceAttribute data)
    {
        if (data == null)
        {
            return new ExperienceAttributeInstance()
            {
                maxExpForThisLevel = 10
            };
        }
        return new ExperienceAttributeInstance()
        {
            //reference = data,
            maxExpForThisLevel = data.Level1Exp,
        };
    }

    public void GainExp(int amount, ExperienceAttribute expDataRef)
    {
        CurrentExp += amount;
        CheckForOverLevel(expDataRef);
    }

    // levels up if necessary.
    public void CheckForOverLevel(ExperienceAttribute expDataRef)
    {

        if (CurrentExp < maxExpForThisLevel)
            return;

        currentLevel++;
        Debug.Log("EDXP: Level up! to level " + currentLevel);

        // Add leftover exp to new level.
        int expLeft = CurrentExp - maxExpForThisLevel;
        CurrentExp = expLeft;

        // Calcualte what the new exprience required for new level is.
        float percentage = (float)currentLevel / (float)expDataRef.MaxLevel;
        //float sample = expLimit.Evaluate(percentage);
        float sample = expDataRef.ExpIncreasePercentage.Evaluate(percentage);
        //float multiplier = Mathf.Max((int)(sample * maxGlobalExpLimit), 1);
        float multiplier = 1;
        int newMaxExp = (int)(maxExpForThisLevel * (1 + sample));
        maxExpForThisLevel = newMaxExp;
        Debug.Log("percentage : " + percentage + "curve result: " + sample + " multiplier: " + multiplier + " -> " + newMaxExp);

    }
}
