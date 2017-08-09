using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMouse : MonoBehaviour {
    GameObject player;
    GameObject spawnPoint;
    public GameObject bullet;
    public GameObject altBullet;
    public Vector3 lookingPos;
    float angle;
    public bool firing;
    public bool altFire;
    public float time;
    bool shootRight;
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
            shootRight = true;
        }
        else
        {
            angle = Mathf.Atan2(-lookPos.y, -lookPos.x) * Mathf.Rad2Deg;
            shootRight = false;

        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if(Input.GetMouseButtonDown(0))
        {
            firing = true;
            StartCoroutine(fire());
        }
        if(Input.GetMouseButtonUp(0))
        {
            firing = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            altFire = true;
            StartCoroutine(alternateFire());
        }
        if (Input.GetMouseButtonUp(1))
        {
            altFire = false;
        }
    }
    IEnumerator fire()
    {
        while(firing)
        {
            GameObject newBullet = Instantiate(bullet, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), spawnPoint.transform.rotation) as GameObject;
            if (!shootRight)
            {
                newBullet.transform.localScale = new Vector3(newBullet.transform.localScale.x * -1, newBullet.transform.localScale.y, newBullet.transform.localScale.z);
            }
            yield return new WaitForSeconds(time);
        }
        
    }
    IEnumerator alternateFire()
    {
        GameObject newAltBullet = Instantiate(altBullet, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), spawnPoint.transform.rotation) as GameObject;
        if (!shootRight)
        {
            newAltBullet.transform.localScale = new Vector3(newAltBullet.transform.localScale.x * -1, newAltBullet.transform.localScale.y, newAltBullet.transform.localScale.z);
        }
        yield return new WaitForSeconds(time);
    }
}
