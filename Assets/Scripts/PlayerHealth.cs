using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float totalHealth;
    float takenDamage;
    public bool invun;
    public GameObject[] parts;
    public int i;
    public float time;


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
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "Smasher" && coll.gameObject.tag == "NotSafe")
        {
            var takenDamage = coll.gameObject.GetComponent<EnemyDamage>().damage;
            totalHealth -= takenDamage;
            checkHealth();
            delay();
        }
    }
    void OnCollisionStay2D(Collision2D stayAttack)
    {
        if (stayAttack.gameObject.tag == "Enemy")
        {
            var takenDamage = stayAttack.gameObject.GetComponent<EnemyDamage>().damage;
            if (invun == false)
            {
                totalHealth -= takenDamage;
                StartCoroutine(delay());
            }
            checkHealth();
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
    private void checkHealth()
    {
        if(totalHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator delay()
    {
        invun = true;
        yield return new WaitForSeconds(time);
        invun = false;
    }
}