using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour
{
    //Public Variables.
    public Transform endPos;
    public float upMovementSpeed;
    public float downMovementSpeed;
    public float downWaitTime;
    public float upWaitTime;
    public int damage;
    
    //Private Variables.
    private Vector3 movedown;
    private Vector3 moveup;
    private bool down;
    private float time;

    void Start()
    {
        moveup = transform.position;
        movedown = endPos.transform.position;
        down = false;
    }

	void Update ()
    {
        /**
        Checks if the smasher is down or up and  then runs a timing script, 
        this timing script will set the time to 0 and then change the boolean down,
        to true or false depending on what it was before. 
        */
        if (gameObject.transform.position.y <= movedown.y)
        {
            time += Time.deltaTime;

            if (time >= downWaitTime)
            {
                time = 0.0f;
                down = true;
            }
        }
        else if(gameObject.transform.position.y >= moveup.y)
        {
            time += Time.deltaTime;

            if (time >= upWaitTime)
            {
                time = 0.0f;
                down = false;
            }
        }

        /**
        This script moves the smasher down and back up depedning on the boolean down.
        */
        if (gameObject.transform.position.y > movedown.y && !down)
        {
            float downValue;
            if(movedown.y * downMovementSpeed > 0)
            {
                downValue = (movedown.y * downMovementSpeed * -1);
            }
            else
            {
                downValue = movedown.y * downMovementSpeed;
            }

            gameObject.transform.position = transform.TransformPoint(0.0f, downValue, 0.0f);
        }
        else if (gameObject.transform.position.y < moveup.y && down)
        {
            gameObject.transform.position = transform.TransformPoint(0.0f, moveup.y / upMovementSpeed, 0.0f);
        }
    }
}
