using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;

    float temp = 100;
    public void TakeDamage (float amount)
    {
        health -= amount;
    }

    public float getSpeed (float input)
    {
        if (health < 100 && health > 50)
        {
            float temp1 = health / 100;
            float temp2 = input * temp1;
            return temp2;
        }
        else if (health <50)
        {
            return 0.0f;
        }
        return input;
    }

    private void Update()
    {

        if (health - temp < 0 )
        {

            Debug.Log("current health = " + health.ToString());
            temp = health;
        }
    }

}
