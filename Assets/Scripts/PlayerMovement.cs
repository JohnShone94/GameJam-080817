using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float xSpeed;
    public float ySpeed;
    float rotate;
    public float startXSpeed;
    public float startYSpeed;
    public float startRotate;
    public bool platformActive;
    public GameObject legs;
    public bool facingRight;
    // Use this for initialization
    void Start ()
    {
        startXSpeed = xSpeed;
        startYSpeed = ySpeed;
        rotate = 2;
        
	}
	// Update is called once per frame
	void Update ()
    {
        if(legs == null)
        {
            findLegs();
        }
		if(Input.GetKey(KeyCode.D))
        {
            xSpeed = startXSpeed;
            rotate = 2;
            facingRight = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xSpeed = -startXSpeed;
            rotate = -2;
            facingRight = false;
        }
        else
        {
            xSpeed = 0;
        }
        if (Input.GetKey(KeyCode.Space) && legs.name != "Tracks(Clone)")
        {
            ySpeed = startYSpeed;
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            xSpeed /= 2.5f;
        }
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + xSpeed, gameObject.transform.position.y + ySpeed);
        gameObject.transform.localScale = new Vector3(rotate, 2, 2);
        ySpeed = 0;

        platformActive = legs.GetComponent<ChangePart>().activatePlatform;
    }
    public void findLegs()
    {
        legs = GameObject.FindGameObjectWithTag("Leg");
    }
    public void resetHealth()
    {
        gameObject.GetComponent<PlayerHealth>().totalHealth = 0;
        gameObject.GetComponent<PlayerHealth>().i = 0;
    }
}
