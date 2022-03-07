using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHudDisplay : MonoBehaviour
{

    public Text magAndReserve;

    public void updateText(float current,float reserve)
    {
        magAndReserve.text = current.ToString() + " / " + reserve.ToString();
    }

}
