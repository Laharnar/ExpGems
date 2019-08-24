using UnityEngine;

public class PlayerMotor : ChildBehaviour {

    // default behaviour
    Vector2 wasdLastVec;
    PlayerMovement player;

    protected void Start()
    {
        player = GetPlayerMovement();
        player.SetFunction(WASDMove);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            wasdLastVec.y += 1f;
            if (wasdLastVec.y != 0)
            {
                player.FacingDirectionY = wasdLastVec.y;
                player.FacingDirectionX = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            wasdLastVec.x += 1f;
            if (wasdLastVec.x != 0)
            {
                player.FacingDirectionX = wasdLastVec.x;
                player.FacingDirectionY = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            wasdLastVec.x -= 1;
            if (wasdLastVec.x != 0)
            {
                player.FacingDirectionX = wasdLastVec.x;
                player.FacingDirectionY = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            wasdLastVec.y -= 1;
            if (wasdLastVec.y != 0)
            {
                player.FacingDirectionY = wasdLastVec.y;
                player.FacingDirectionX = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
            wasdLastVec.y -= 1;
        if (Input.GetKeyUp(KeyCode.D))
            wasdLastVec.x -= 1;
        if (Input.GetKeyUp(KeyCode.A))
            wasdLastVec.x += 1;
        if (Input.GetKeyUp(KeyCode.S))
            wasdLastVec.y += 1;


        /*
        if (Input.GetKeyUp(KeyCode.W))
            wasdLastVec.y = 0;
        if (Input.GetKeyUp(KeyCode.D))
            wasdLastVec.x = 0;
        if (Input.GetKeyUp(KeyCode.A))
            wasdLastVec.x = 0;
        if (Input.GetKeyUp(KeyCode.S))
            wasdLastVec.y = 0;*/

    }

    Vector2 WASDMove()
    {
        
        return wasdLastVec;
    }
}
