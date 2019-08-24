using UnityEngine;

[CreateAssetMenu(fileName = "ExpAttribute", menuName = "Exp/ExpAttribute", order = 1)]
internal class ExperienceAttribute : ScriptableObject {

    [SerializeField] AnimationCurve expIncreasePercentage;
    [SerializeField] int maxLevel = 80;
    [SerializeField] int maxGlobalExpLimit = 1000000;

    [SerializeField] int maxExpForLevel1 = 10;

    public int Level1Exp { get => maxExpForLevel1; }
    public AnimationCurve ExpIncreasePercentage { get => expIncreasePercentage; }
    public int MaxLevel { get => maxLevel; }
    public int MaxGlobalExpLimit { get => maxGlobalExpLimit; }
}
