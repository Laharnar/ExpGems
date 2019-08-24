using UnityEngine;

public class ParentBehaviour : MonoBehaviour {
    [SerializeField] Rigidbody2D rig2dParent;
    public Rigidbody2D Rig2DParent { get { return rig2dParent; } }

    [SerializeField] PlayerStats stats;
    public PlayerStats Stats { get => stats; }

    [SerializeField] UnitKill unitKill;
    public UnitKill UnitKill { get => unitKill; }

    [SerializeField] CharacterAnimator characterAnimations;
    public CharacterAnimator CharacterAnimations { get => characterAnimations; }

    private void Awake()
    {
        if (unitKill == null)
        {
            unitKill = gameObject.GetComponentInChildren<UnitKill>();
        }
        if (characterAnimations == null)
        {
            characterAnimations = gameObject.GetComponentInChildren<CharacterAnimator>();
        }
    }
}
