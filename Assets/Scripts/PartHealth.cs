using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartHealth : MonoBehaviour {
    public float partHealth;
	// Use this for initialization
	void Start ()
    {
        if (gameObject.transform.parent != null)
        {
            gameObject.transform.parent.GetComponent<PlayerMovement>().resetHealth();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	}
}
