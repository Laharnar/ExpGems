using UnityEngine;

public abstract class ChildBehaviour:MonoBehaviour {

    [SerializeField] bool useParentAsRoot;
    [SerializeField] protected bool useRigidbody;

    Transform gParent;
    Transform usingObj;

    public bool UseParentAsRoot { get { return useParentAsRoot; } }
    public Transform RootObj { get { return usingObj; } }

    protected void Awake()
    {
        gParent = transform.parent;

        InternalInit();

        GlobalInit();
    }

    public virtual void GlobalInit()
    {
        Debug.Log("Globa init nothing.");
    }

    protected virtual void InternalInit()
    {
        // assign who to use as search reference.
        if (useParentAsRoot)
        {
            usingObj = gParent;
        }
        else
        {
            usingObj = transform;
        }
    }

    protected Rigidbody2D GetRigidbody2D()
    {
        if (useRigidbody)
            return usingObj.GetComponent<ParentBehaviour>().Rig2DParent;
        return null;
    }

    protected PlayerMovement GetPlayerMovement()
    {
        return usingObj.GetComponent<PlayerMovement>();
    }

    public PlayerStats GetStats()
    {
        ParentBehaviour pb = usingObj.GetComponent<ParentBehaviour>();
        return pb.Stats;
    }
}
