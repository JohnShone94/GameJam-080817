using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    public float thresholdOff;
    public float thresholdOn;
    public float damage;
    public GameObject flames;

    private bool fire;
    private float time;
    private bool detected;
    private GameObject Player;
    void Start ()
    {
        fire = false;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update ()
    {

        if (!fire)
        {
            time += Time.deltaTime;
            flames.GetComponent<SpriteRenderer>().enabled = false;

            if (time >= thresholdOff )
            {
                time = 0.0f;
                fire = true;
            }
        }
        if(fire)
        {
            time += Time.deltaTime;
            flames.GetComponent<SpriteRenderer>().enabled = true;

            if (time >= thresholdOn)
            {
                time = 0.0f;
                fire = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            detected = true;
        }
        DetectedPlayer();
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            detected = false;
        }
        DetectedPlayer();
    }

    private void DetectedPlayer()
    {
        if (detected)
        {
            StartCoroutine(delayDamage());
        }

    }

    IEnumerator delayDamage()
    {
        yield return new WaitForSeconds(1);
        if (fire)
        {
            Player.GetComponent<PlayerHealth>().removeHealth(damage);
        }
        DetectedPlayer();
    }
}
