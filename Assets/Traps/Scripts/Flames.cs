using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    public float thresholdOff;
    public float thresholdOn;
    public float dmg;
    public GameObject flames;

    private bool fire;
    private float time;
    void Start ()
    {
        fire = false;
	}

	void Update ()
    {

        if (!fire)
        {
            time += Time.deltaTime;
            flames.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<EnemyDamage>().damage = 0;
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
            if (time >= 1.0f)
            {
                gameObject.GetComponent<EnemyDamage>().damage = dmg;
                time = 0.0f;
            }

            if (time >= thresholdOn)
            {
                time = 0.0f;
                fire = false;
            }
        }


    }
}
