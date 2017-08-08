using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMouse : MonoBehaviour {
    GameObject player;
    GameObject spawnPoint;
    public GameObject bullet;
    public Vector3 lookingPos;
    float angle;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - transform.position;
        if (player.GetComponent <PlayerMovement>().facingRight == true)
        {
            angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        }
        else
        {
            angle = Mathf.Atan2(-lookPos.y, -lookPos.x) * Mathf.Rad2Deg;
        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left click.");
            GameObject newBullet = Instantiate(bullet, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), spawnPoint.transform.rotation) as GameObject;
        }
    }
}
