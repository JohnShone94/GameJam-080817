using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroWater : MonoBehaviour
{
    public float thresholdOff;
    public float thresholdOn;
    public float damage;

    private bool electro;
    private float time;
    private bool detected;
    private GameObject Player;
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	void Update ()
    {
        if (!electro)
        {
            time += Time.deltaTime;
            //gameObject.GetComponent<EnemyDamage>().damage = 0;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);

            if (time >= thresholdOff)
            {
                time = 0.0f;
                electro = true;
            }
        }
        if (electro)
        {
            time += Time.deltaTime;
            //gameObject.GetComponent<EnemyDamage>().damage = damage;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f);

            if (time >= thresholdOn)
            {
                time = 0.0f;
                electro = false;
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
        if (electro)
        {
            Player.GetComponent<PlayerHealth>().removeHealth(damage);
        }
            DetectedPlayer();
    }
}
