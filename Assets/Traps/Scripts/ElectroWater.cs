using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroWater : MonoBehaviour
{
    public float thresholdOff;
    public float thresholdOn;
    public float dmg;

    private bool electro;
    private float time;
    void Start ()
    {
		
	}
	void Update ()
    {
        if (!electro)
        {
            time += Time.deltaTime;
            gameObject.GetComponent<EnemyDamage>().damage = 0;
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
            if (time >= 1.0f)
            {
                gameObject.GetComponent<EnemyDamage>().damage = dmg;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f);
                time = 0.0f;
            }

            if (time >= thresholdOn)
            {
                time = 0.0f;
                electro = false;
            }
        }

    }
}
