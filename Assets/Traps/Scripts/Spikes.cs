using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage;

    private float time;
    private bool detected;
    private GameObject Player;
    float startDamage;
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        startDamage = damage;
    }
	
	void Update ()
    {
        if (gameObject.name == "Spikes" && GameObject.FindGameObjectWithTag("Leg").name == "Tracks(Clone)")
        {
           damage = 0;
        }
        else
            damage = startDamage;
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
        Player.GetComponent<PlayerHealth>().removeHealth(damage);
        DetectedPlayer();
    }
}
