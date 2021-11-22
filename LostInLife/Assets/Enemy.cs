
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage (float amount)
        {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
        else if (health == 100f)
        {
            //proceed as normal
        }
        else if (health == 75f)
        {
            //force the enemy to go limp 
        }
        else if (health == 50f)
        {
            //force enemny to stop moving and lie on the ground but still allowed to shoot
        }

    }


    public void Update()
    {

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
