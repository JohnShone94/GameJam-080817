using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMoce : MonoBehaviour {
    GameObject player;
    public float bulletSpeed;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<PlayerMovement>().facingRight == false)
            bulletSpeed *= -1;       
    }
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.position += (transform.right * bulletSpeed);
        //GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed * 10);
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Cieling")
        {
            Destroy(gameObject);
        }
    }
}

