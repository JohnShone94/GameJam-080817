using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePart : MonoBehaviour {
    public GameObject nextPart;
    public GameObject platform;
    public bool activatePlatform;
    KeyCode selector;
    
	// Use this for initialization
	void Start ()
    {
        if(gameObject.tag == "Arm")
        {
            selector = KeyCode.X;
        }
        if (gameObject.tag == "Head")
        {
            selector = KeyCode.Z;
        }
        if (gameObject.tag == "Leg")
        {
            selector = KeyCode.C;
        }
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(selector) && (gameObject.transform.parent.GetComponent<PlayerMovement>().platformActive))
        {
            GameObject newPart = Instantiate(nextPart, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;
            nextPart.tag = gameObject.tag;
            nextPart.layer = gameObject.layer;
            newPart.transform.parent = gameObject.transform.parent;
            newPart.transform.localScale = new Vector3(1, 1, 1);
            gameObject.transform.parent.GetComponent<PlayerMovement>().findLegs();
            gameObject.transform.parent.GetComponent<PlayerMovement>().resetHealth();
            Destroy(gameObject);
        }
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Platform")
                activatePlatform = true;
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        activatePlatform = false;
    }
}
