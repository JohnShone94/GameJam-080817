using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAltMove : MonoBehaviour {
    GameObject player;
    public float bulletSpeed;
    public int reflect;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<PlayerMovement>().facingRight == false)
            bulletSpeed *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (transform.right * bulletSpeed);
        //GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed * 10);
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            bulletSpeed *= -1;
            gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z *-1, gameObject.transform.rotation.w);
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, 2, 1);
            reflect--;
            if (reflect == 0)
            {
                Destroy(gameObject);
            }
        }
        if (coll.gameObject.tag == "Cieling")
        {
            //bulletSpeed *= -1;
            gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z * -1, gameObject.transform.rotation.w);
            //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, 2, 1);
            reflect--;
            if (reflect == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
