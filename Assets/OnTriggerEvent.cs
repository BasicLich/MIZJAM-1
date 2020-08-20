using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{

    public int playerLayer;
    public UnityEvent firesOnce, firesAlways;
    bool firedYet;



    private void OnTriggerEnter(Collider other) {
        

        if (other.gameObject.layer == playerLayer) {


            if (!firedYet) {
                firesOnce.Invoke();
                firedYet = true;
            }

            firesAlways.Invoke();

        }


    }


}
