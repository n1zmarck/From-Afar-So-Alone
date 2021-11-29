
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage (float amount)
    {
        health -= amount;
    }


    public void Update()
    {
        if (health <= 0)
        {
            //Die();
            this.gameObject.transform.gameObject.SetActive(false);
            Destroy(this.gameObject.transform.gameObject);

        }
        else if (health == 75f)
        {
            
        }
        else if (health == 50f)
        {
            //force enemny to stop moving and lie on the ground but still allowed to shoot
        }
    }

    void Die()
    {
        
        Destroy(gameObject);
        //Destroy(this.gameObject);
    }
}
