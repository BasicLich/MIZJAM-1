using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : HeldItem {

    [Header("Gun")]
    public Transform shootPoint;
    public Projectile bullet;
    public float bulletSpeed;
    public int shotDamage = 1;

    public SpreadAimSpot spreadSpot;

    public override void OnInitialSetup(ItemManager i) {
        base.OnEquip(i);

        if (spreadSpot) {
            spreadSpot = Instantiate(spreadSpot, GroundController.instance.aimPoint);
            spreadSpot.transform.localPosition = Vector3.zero;
        }

    }


    public override void OnClick() {


        

        Projectile p = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        p.init(GroundController.instance.aimPoint.forward, bulletSpeed, GroundController.instance.aimPoint.position, enemyLayer, shotDamage);
       


    }



}
