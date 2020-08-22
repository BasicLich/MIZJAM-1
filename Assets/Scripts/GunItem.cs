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
    public int startingAmmo = 10;
    [HideInInspector]
    public int currentAmmo = 10;
    public int maxAmmo = 30;

    public float shotInterval = 1f;
    float lastShotTime;

    private void Awake() {
        currentAmmo = startingAmmo;
    }


    public override void OnInitialSetup(ItemManager i) {
        base.OnInitialSetup(i);

        if (spreadSpot) {
            spreadSpot = Instantiate(spreadSpot, GroundController.instance.aimPoint);
            spreadSpot.transform.localPosition = Vector3.zero;
        }

        itemButton.wordBuilder.words = currentAmmo.ToString();
        itemButton.wordBuilder.CreateWord();

    }


    public override void OnPickUpSecondItem(HeldItem h) {
        AddAmmo(((GunItem)h).currentAmmo);
    }

    public void AddAmmo(int amt) {
        currentAmmo += amt;
        currentAmmo = Mathf.Min(currentAmmo, maxAmmo);
        itemButton.wordBuilder.words = currentAmmo.ToString();
        itemButton.wordBuilder.CreateWord();
    }


    public override void OnClick() {




        if (currentAmmo > 0 && lastShotTime <= Time.time) {
            currentAmmo--;
            ShootProjectile();
            itemButton.wordBuilder.words = currentAmmo.ToString();
            itemButton.wordBuilder.CreateWord();
            lastShotTime = Time.time + shotInterval;
        } else if (currentAmmo <= 0 ) {
            noAmmoSource.Play();
        }

    }

    public AudioSource gunSource;
    public AudioSource noAmmoSource;
    public virtual void ShootProjectile() {
        Projectile p = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        p.init(GroundController.instance.aimPoint.forward, bulletSpeed, GroundController.instance.aimPoint.position, 10, shotDamage);
    
        if (spreadSpot) {
            foreach (Transform t in spreadSpot.otherShots) {
                Projectile p1 = Instantiate(bullet, shootPoint.position, Quaternion.identity);
                p1.init(t.forward, bulletSpeed, t.position, 10, shotDamage);
            }
        }

        gunSource.Play();

    }


}
