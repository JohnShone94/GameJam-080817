using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float totalHealth;
    float takenDamage;
    public GameObject[] parts;
    public int i;

    // Use this for initialization
    void Start()
    {
        totalHealth = 0;
        i = 0;
        addHealth();
    }

    // Update is called once per frame
    void Update()
    {
        addHealth();
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            var takenDamage = coll.gameObject.GetComponent<EnemyDamage>().damage;
            totalHealth -= takenDamage;
        }
    }
    public void addHealth()
    {
        parts[0] = GameObject.FindGameObjectWithTag("Head");
        parts[1] = GameObject.FindGameObjectWithTag("Torso");
        parts[2] = GameObject.FindGameObjectWithTag("Arm");
        parts[3] = GameObject.FindGameObjectWithTag("Leg");

        while (i < parts.Length)
        {
            if(parts[i] != null)
            {
                totalHealth += parts[i].GetComponent<PartHealth>().partHealth;
                i++;
            }
            else
            {
                totalHealth = 0;
                i = 0;
            }
            
        }
    }
}