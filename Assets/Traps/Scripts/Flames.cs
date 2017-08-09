using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    public int damage;
    public float thresholdOff;
    public float thresholdOn;
    public GameObject fireObj;

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
            fireObj.SetActive(true);
            if (time >= thresholdOff )
            {
                time = 0.0f;
                fire = true;
            }
        }
        if(fire)
        {
            time += Time.deltaTime;
            fireObj.SetActive(false);
            if (time >= thresholdOn)
            {
                time = 0.0f;
                fire = false;
            }
        }


    }
}
