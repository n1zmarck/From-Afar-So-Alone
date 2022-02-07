using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{

    public Slider SEvol;
    public Slider BGMvol;


    private void Awake()
    {
        SEvol.maxValue = 1.00f;
        SEvol.minValue= 0.00f;
        
        BGMvol.maxValue = 1.00f;
        BGMvol.minValue= 0.00f;
        //set initial restriction on audio slider 

        SEvol.value = PlayerPrefs.GetFloat("SEvol",1);
        BGMvol.value = PlayerPrefs.GetFloat("BGMvol",1);
        //update the values on slider.
    }

    
    public void SEvolChange(float val)
    {
        PlayerPrefs.SetFloat("SEvol", val);
        PlayerPrefs.Save();
    }
    public void BGMvolChange(float val)
    {
        PlayerPrefs.SetFloat("BGMvol", val);
        PlayerPrefs.Save();
    }

}
