using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobshoot : StateMachineBehaviour
{
    public GameObject AimHit;
    public AiSensor sensor;

    GameObject findPlayer()
    {
        // GameObject FindPlayer;
        if (this.sensor.objects.Count > 0)
        {
            return this.sensor.objects[0];
        }
        return null;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // on state update
        AimHit = findPlayer(); 

        AimHit.GetComponentInParent<KeyboardController>().gameObject.SetActive(false);

    }



}
