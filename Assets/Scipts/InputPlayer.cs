using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputPlayer : MonoBehaviour
{
    MoveScript moveScript;
    PlayerControl playerControl;

    void Awake()
    {
        moveScript = GetComponent<MoveScript>();
        playerControl = GetComponent<PlayerControl>();
    }
    void Update()
    {
        Vector3 dir = Vector3.zero;
        if(playerControl.isAlive)
        {
            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                playerControl.AttemptFire();
            }
            dir.Normalize();
        }

        moveScript.SetDirection(dir);
    }
}
