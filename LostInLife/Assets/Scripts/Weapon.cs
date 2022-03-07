
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float DmrReserve, SgReserve;
    public float DMRMag, SGMag;
    public weaponType currentWeapon;

    public bool isGamePaused = false;

    public GameObject shotgun;
    public GameObject Rifle;

    public PlayerHudDisplay hudDisplay;

    public AudioSource DMR, SG;

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
            return 10f;
        }
        

        return 0f;
    }

    private void Start()
    {
        DMRMag = 15f;
        SGMag = 7f;
        DMR.volume = (PlayerPrefs.GetFloat("SEvol", 1));
        SG.volume = (PlayerPrefs.GetFloat("SEvol", 1));

    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("primary");
                // weapon 1
                Rifle.SetActive(true);
                shotgun.SetActive(false);
                currentWeapon = weaponType.AssaultRifle;

                hudDisplay.updateText(DMRMag, DmrReserve);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Secondary");
                //weapon 2
                shotgun.SetActive(true);
                Rifle.SetActive(false);
                currentWeapon = weaponType.Shotgun;
                hudDisplay.updateText(SGMag, SgReserve);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Backup Knife or Fists");
                // Seperate Backup
                shotgun.SetActive(false);
                Rifle.SetActive(false);

                currentWeapon = weaponType.Melee;
            }




            if (Input.GetMouseButtonDown(0))
            {
                if (currentWeapon == weaponType.AssaultRifle && DMRMag > 0 || currentWeapon == weaponType.Shotgun && SGMag > 0)
                {
                    shoot(RangeCalc(currentWeapon));
                    Debug.Log("fired");
                }


            }
            if (Input.GetMouseButton(1))
            {
                // zoom scope
                Debug.Log("zoomies");
            }

            if (Input.GetKey(KeyCode.R))
            {
                switch (currentWeapon)
                {
                    case weaponType.AssaultRifle:
                        DMRMag += 30; DmrReserve -= 30; hudDisplay.updateText(DMRMag, DmrReserve); break;
                    case weaponType.Shotgun:
                        SGMag += 7; SgReserve -= 7; hudDisplay.updateText(SGMag, SgReserve); break;
                    case weaponType.Melee:
                        break;
                }
            }
        }
       
    }

    void shoot(float range)
    {
        //particle.Play();

        if (currentWeapon == weaponType.AssaultRifle)
        {
            DMR.Play();
            DMRMag -= 1;
            hudDisplay.updateText(DMRMag, DmrReserve);
        }
        else if (currentWeapon == weaponType.Shotgun)
        {
            SG.Play();
            SGMag -= 1;
            hudDisplay.updateText(SGMag, SgReserve);
        }
        else if (currentWeapon == weaponType.Melee)
        {
        }


        RaycastHit hit;


        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, range))
        {
            // Then you could find your GO with a specific tag by doing something like:
            if (hit.collider.tag == "Head")
            {
                Debug.Log("HeadShot!");
                Enemy enemy = hit.transform.gameObject.GetComponentInParent<Enemy>();
                //hit.collider.transform.parent.gameObject.SetActive(false);
                hit.transform.gameObject.GetComponentInParent<Enemy>().TakeDamage(100f);


                if (currentWeapon == weaponType.Melee)
                {
                    enemy.TakeDamage(15f);
                }
            }
            else if (hit.collider.tag == "UpperTorso" || hit.collider.tag == "LowerTorso")
            {
                Debug.Log("ChestHit!");
                //hit.collider.gameObject.SetActive(false);
                Enemy enemy = hit.transform.gameObject.GetComponentInParent<Enemy>();
      
                    enemy.TakeDamage(50f);
                
                if (enemy != null && currentWeapon == weaponType.Melee)
                {
                    enemy.TakeDamage(40f);
                }

            }
            else if (hit.collider.tag == "Legs")
            {
                Debug.Log("LEGS AND KNEES!");
                // hit.collider.gameObject.SetActive(false);
                Enemy enemy = hit.transform.gameObject.GetComponentInParent<Enemy>();
                hit.transform.gameObject.GetComponentInParent<Enemy>().TakeDamage(25f);

                if (currentWeapon == weaponType.Melee)
                {
                    enemy.TakeDamage(15f);
                }

            }



        }
    }
}
