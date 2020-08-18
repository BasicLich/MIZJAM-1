using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{

    public UnityEvent OnPickup;


    public void AddHealth() {


        

    }


    public void Heal() {
        ItemManager.Heal();
    }


    public void SetText(string s) {

        
        ItemManager.SetText(s);

    }


}
