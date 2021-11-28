using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class WpFab : MonoBehaviour
{
    public int maximumBulletsPerMag;
    public int currentRoundsLeftInMag;
    public bool currentlyEquipped;
    public bool currentlyInHand;
    public int BulletsLeftInHand;

    public abstract void shoot();

    public abstract void zoomScope();

    public abstract void Reload();

}

public class Shotgun : WpFab
{
    public int maximumBulletsPerMag = 10;
    public int currentRoundsLeftInMag = 10;
    public bool currentlyEquipped = false;
    public bool currentlyInHand = false;
    public int BulletsLeftInHand = 100;
    public bool fired = false;

    public override void Reload()
    {
        if (BulletsLeftInHand > 0 && currentlyInHand == true)
        {
            for (int i = 0; i <= (maximumBulletsPerMag - currentRoundsLeftInMag); i++)
            {
                currentRoundsLeftInMag += i;
                BulletsLeftInHand -= i;
            }
        }

    }

    public override void shoot()
    {
        if (currentRoundsLeftInMag > 0 && currentlyInHand == true && fired == false)
        {
            currentRoundsLeftInMag -= 1;
        }

    }



    public override void zoomScope()
    {
        
    }
}

public class AssaultRifle : WpFab
{
    public int maximumBulletsPerMag;
    public int currentRoundsLeftInMag;
    public bool currentlyEquipped;
    public bool currentlyInHand;
    public int BulletsLeftInHand;

    public float shootDelay;

    public override void Reload()
    {
        throw new System.NotImplementedException();
    }

    public override void shoot()
    {
        throw new System.NotImplementedException();
    }

    public override void zoomScope()
    {
        throw new System.NotImplementedException();
    }
}