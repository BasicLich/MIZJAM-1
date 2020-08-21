using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class HeldItem : MonoBehaviour
{


    
    public Sprite reticle;
    public Sprite icon;
    public bool OnCooldown;
    public LayerMask enemyLayer;
    public Vector3 posOffset, rotationOffset;
    [HideInInspector]
    public ItemButton itemButton;
    public UnityEvent OnPickup;
    public bool canSwitch = true;
    

    public virtual void OnInitialSetup(ItemManager i) {

        if (GetComponent<Rigidbody>()) {
            Destroy(GetComponent<Rigidbody>());
            foreach (Collider col in GetComponents<Collider>()) {
                Destroy(col);
            }
        }
        canSwitch = true;

    }



    public virtual void OnPickUpSecondItem(HeldItem h) {

    }

    public virtual void OnEquip(ItemManager i) {

        i.reticle.sprite = reticle;


    }


    public virtual void OnClick() {



    }
}
