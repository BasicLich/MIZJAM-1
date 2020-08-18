using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class HeldItem : MonoBehaviour
{


    [Header("Gun")]
    public Sprite reticle;
    public Sprite icon;
    public bool OnCooldown;
    public LayerMask enemyLayer;
    public Vector3 posOffset, rotationOffset;
    [HideInInspector]
    public ItemButton itemButton;


    public virtual void OnInitialSetup(ItemManager i) {

    }

    public virtual void OnEquip(ItemManager i) {

        i.reticle.sprite = reticle;

    }


    public virtual void OnClick() {



    }
}
