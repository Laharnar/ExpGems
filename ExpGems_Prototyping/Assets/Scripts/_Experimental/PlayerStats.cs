using UnityEngine;

public class PlayerStats : ChildBehaviour {

    [SerializeField] Stat speed;

    protected override void InternalInit()
    {
        base.InternalInit();

        PlayerMovement move = GetPlayerMovement();
        move.SetSpeed(speed);
    }

}
