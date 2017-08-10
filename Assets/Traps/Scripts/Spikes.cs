using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private float time;
    public float da;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        time += Time.deltaTime;
    }

    void OnCollisonStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(time >= 1.0f)
            {
                gameObject.GetComponent<EnemyDamage>().damage = 25;
                time = 0.0f;
            }
            else
            {
                gameObject.GetComponent<EnemyDamage>().damage = 0;
                time += Time.deltaTime;
            }

        }
    }
    

}
