using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDamage : MonoBehaviour {
    public float damage;
    float startDamage;
    // Use this for initialization
    void Start ()
    {
        startDamage = damage;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "Spikes" && GameObject.FindGameObjectWithTag("Leg").name == "Tracks(Clone)")
        {
            damage = 0;
        }
        else
            damage = startDamage;
		
	}
}
