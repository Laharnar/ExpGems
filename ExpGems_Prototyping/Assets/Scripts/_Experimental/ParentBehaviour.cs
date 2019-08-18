using UnityEngine;

public class ParentBehaviour : MonoBehaviour {
    [SerializeField] Rigidbody2D rig2dParent;
    public Rigidbody2D Rig2DParent { get { return rig2dParent; } }

    [SerializeField] PlayerStats stats;
    public PlayerStats Stats { get => stats; }

    [SerializeField] UnitKill unitKill;
    public UnitKill UnitKill { get => unitKill; }

    private void Awake()
    {
        if (unitKill == null)
        {
            unitKill = GameObject.FindObjectOfType<UnitKill>();
        }
    }
}
