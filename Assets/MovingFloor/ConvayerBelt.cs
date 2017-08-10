using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvayerBelt : MonoBehaviour
{
    public Transform begin;
    public Transform end;
    public float movementSpeed;

    private Vector3 moveRight;
    private Vector3 startPos;

    void Start ()
    {
        startPos = begin.transform.position;
        moveRight = end.transform.position;
    }

	void Update ()
    {
        float rightSpeed = moveRight.x * movementSpeed;
        if (gameObject.transform.position.x > moveRight.x)
        {
            gameObject.transform.position = startPos;
        }
        else if (gameObject.transform.position.x < moveRight.x)
        {
            gameObject.transform.position = transform.TransformPoint(rightSpeed, 0.0f, 0.0f);
        }
    }
}
