
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public weaponType currentWeapon;
    //public ParticleSystem particle;
    //public GameObject impactEffect;
    public GameObject shotgun;
    public GameObject Rifle;

    public AudioSource DMR, SG, punch;

    public enum weaponType
    {
        AssaultRifle, Shotgun, Melee
    }


    public float RangeCalc(weaponType type)
    {
        if (type == weaponType.AssaultRifle)
        {
            return 100f;
        }
        else if (type == weaponType.Shotgun)
        {
            return 25f;
        }
        else if (type == weaponType.Melee)
        {
            return 1f;
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
            Rifle.SetActive(true);
            shotgun.SetActive(false);
            currentWeapon = weaponType.AssaultRifle;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Secondary");
            //weapon 2
            shotgun.SetActive(true);
            Rifle.SetActive(false);
            currentWeapon = weaponType.Shotgun;
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Backup Knife or Fists");
            // Seperate Backup
            shotgun.SetActive(false);
            Rifle.SetActive(false);

            currentWeapon = weaponType.Melee;
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
        //particle.Play();

        RaycastHit hit;

        if (currentWeapon == weaponType.AssaultRifle)
        {
            DMR.Play();
        }
        else if (currentWeapon == weaponType.Shotgun)
        {
            SG.Play();
        }
        else if (currentWeapon == weaponType.Melee)
        {
            punch.Play();
        }


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
                if (enemy != null && currentWeapon == weaponType.Melee)
                {
                    enemy.TakeDamage(15f);
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
                if (enemy != null && currentWeapon == weaponType.Melee)
                {
                    enemy.TakeDamage(15f);
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
                if (enemy != null && currentWeapon == weaponType.Melee)
                {
                    enemy.TakeDamage(15f);
                }

            }


           // GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

           // Destroy(impactGO, 2f);
        }
    }
}
