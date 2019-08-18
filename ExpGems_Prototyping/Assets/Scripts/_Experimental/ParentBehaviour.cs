using UnityEngine;

public class ParentBehaviour : MonoBehaviour {
    [SerializeField] Rigidbody2D rig2dParent;
    public Rigidbody2D Rig2DParent { get { return rig2dParent; } }

    [SerializeField]
    PlayerStats stats;
    public PlayerStats Stats { get => stats; }
}
