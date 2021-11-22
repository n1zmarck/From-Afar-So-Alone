
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public weaponType currentWeapon;
    public ParticleSystem particle;
    public GameObject impactEffect;


    public enum weaponType
    {
        AssaultRifle, Shotgun, RocketLauncher, SniperRifle
    }


    public float RangeCalc(weaponType type)
    {
        if (type == weaponType.AssaultRifle)
        {
            return 100f;
        }
        else if (type == weaponType.SniperRifle)
        {
            return 25f;
        }
        else if (type == weaponType.RocketLauncher)
        {
            return 1f;
        }
        else if (type == weaponType.Shotgun)
        {
            return 25f;
        }

        return 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("primary");
            // weapon 1
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Secondary");
            //weapon 2
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Backup Knife or Fists"); 
            // Seperate Backup
        }




        if (Input.GetMouseButton(0))
        {
            shoot(RangeCalc(currentWeapon));
            Debug.Log("fired");
            
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // zoom scope
            Debug.Log("zoomies");
        }
    }

    void shoot(float range)
    {
        particle.Play();

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, range))
        {
            // Then you could find your GO with a specific tag by doing something like:
            if (hit.collider.tag == "Head")
            {
                Debug.Log("HeadShot!");
                //hit.collider.transform.parent.gameObject.SetActive(false);
               Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(100f);
                }
            }
            else if (hit.collider.tag == "UpperTorso")
            {
                Debug.Log("ChestHit!");
                //hit.collider.gameObject.SetActive(false);
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(50f);
                }

            }
            else if (hit.collider.tag == "Legs")
            {
                Debug.Log("LEGS AND KNEES!");
               // hit.collider.gameObject.SetActive(false);
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(25f);
                }

            }


            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impactGO, 2f);
        }
    }
}
