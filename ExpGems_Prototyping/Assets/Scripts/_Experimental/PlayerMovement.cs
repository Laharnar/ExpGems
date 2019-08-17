using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ChildBehaviour {

    Rigidbody2D rig2;

    delegate Vector2 MoveFunction();
    MoveFunction moveFun;
    
    // default behaviour
    Vector2 wasdLastVec;

    float speed;

    protected override void InternalInit()
    {
        base.InternalInit();

        rig2 = GetRigidbody2D();

        // init default behaviour
        moveFun = WASDMove;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveFun != null)
            Move(moveFun.Invoke());
    }

    private void Move(Vector2 dir)
    {
        rig2.MovePosition(rig2.position + dir*Time.fixedDeltaTime * speed);
    }

    Vector2 WASDMove()
    {
        if (Input.GetKey(KeyCode.W))
            wasdLastVec.y = 1f;
        if (Input.GetKey(KeyCode.D))
            wasdLastVec.x = 1f;
        if (Input.GetKey(KeyCode.A))
            wasdLastVec.x = -1;
        if (Input.GetKey(KeyCode.S))
            wasdLastVec.y = -1;

        if (Input.GetKeyUp(KeyCode.W))
            wasdLastVec.y = 0;
        if (Input.GetKeyUp(KeyCode.D))
            wasdLastVec.x = 0;
        if (Input.GetKeyUp(KeyCode.A))
            wasdLastVec.x = 0;
        if (Input.GetKeyUp(KeyCode.S))
            wasdLastVec.y = 0;
        return wasdLastVec;
    }

    internal void SetSpeed(Stat speed)
    {
        this.speed = speed.GetFloat();
    }
}
