using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : ChildBehaviour {

    public delegate Vector2 MoveFunction();
    Rigidbody2D rig2;
    MoveFunction moveFun;

    float facingDirectionX = 1;
    float facingDirectionY = 1;

    // in which direction last move pointed.
    public Vector2 LastDirection { get { return new Vector2(facingDirectionX, facingDirectionY); } }

    // where the sprite should be directioned.
    public float FacingDirectionX { get => facingDirectionX; set => facingDirectionX = value; }
    public float FacingDirectionY { get => facingDirectionY; set => facingDirectionY = value; }

    float speed;

    protected override void InternalInit()
    {
        base.InternalInit();

        rig2 = GetRigidbody2D();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveFun != null)
        { 
            Move(moveFun.Invoke());
        }
    }

    private void Move(Vector2 dir)
    {
        rig2.transform.localScale = new Vector3(facingDirectionX != 0 ? facingDirectionX : 1, rig2.transform.localScale.y, rig2.transform.localScale.z);

        rig2.MovePosition(rig2.position + dir*Time.fixedDeltaTime * speed);
    }

    internal void SetSpeed(Stat speed)
    {
        this.speed = Stat.GetFloat(speed);
        if (this.speed == 0)
        {
            QuickLog.Msg("Speed is 0. Assign it in prefabs.");
        }
    }

    internal void SetFunction(PlayerMovement.MoveFunction fun)
    {
        moveFun = fun;
    }
}
