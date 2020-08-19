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
    public int currentAmmo = 10;
    public int maxAmmo = 30;
    


    public override void OnInitialSetup(ItemManager i) {
        base.OnEquip(i);

        if (spreadSpot) {
            spreadSpot = Instantiate(spreadSpot, GroundController.instance.aimPoint);
            spreadSpot.transform.localPosition = Vector3.zero;
        }

    }


    public override void OnClick() {




        if (currentAmmo > 0) {
            Projectile p = Instantiate(bullet, shootPoint.position, Quaternion.identity);
            p.init(GroundController.instance.aimPoint.forward, bulletSpeed, GroundController.instance.aimPoint.position, enemyLayer, shotDamage);
            currentAmmo--;
            itemButton.wordBuilder.words = currentAmmo.ToString();
            itemButton.wordBuilder.CreateWord();
        }

    }



}
