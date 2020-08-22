using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RexState { IDLE, MACHINEGUN, WALL }

public class DeusRex : Unit
{

    public float shootSpeed = 10f;
    public List<Projectile> bossBullets;
    public Transform shootPoint;

    [Header("Machine Gun")]
    public int numberOfBullets;
    public float timeInBetweenBullets =  0.2f;
    public float timeAfterAttack = 5f;
    WaitForSeconds mBullets, mWait;


    [Header("WallOfBullets")]
    public int width,height;
    public float wallTime;
    WaitForSeconds wallWait;
    public int waves = 3;
    public float timeInBetweenWaves;
    WaitForSeconds wWaves;

    Transform target;



    private void Start() {
        target = GroundController.instance.transform;
        wallWait = new WaitForSeconds(wallTime);
        mBullets = new WaitForSeconds(timeInBetweenBullets);
        mWait = new WaitForSeconds(timeAfterAttack);
        wWaves = new WaitForSeconds(timeInBetweenWaves);
        StartCoroutine(StateMachine());
    }


    private void Update() {
        transform.LookAt(target);
        SplashCheck();
    }

    public override void OnHit() {
        base.OnHit();


        StartSplash();
    }


    [Header("Splash Settings")]
    public MeshRenderer mRenderer;
    public Material normal, damage;
    public float splashLength;
    private float splashCounter;


    public void StartSplash() {
        mRenderer.material = damage;
        splashCounter = splashLength;
    }

    public void SplashCheck() {
        if (splashCounter > 0) {
            splashCounter -= Time.deltaTime;
            if (splashCounter <= 0) {
                mRenderer.material = normal;
            }
        }
    }


    IEnumerator StateMachine(){

        while (true) {

            int options = Random.Range(0, 2);

            switch (options) {
                case 0:
                    yield return WallOfBullets();
                    break;
                case 1:
                    yield return MachineGun();
                    break;
             
            }


        }




    }



    IEnumerator MachineGun() {



        int index = 0;

        while (index < numberOfBullets) {

            Projectile p = Instantiate(bossBullets.PickRandom(), shootPoint.position, Quaternion.identity);
            p.init((target.transform.position - shootPoint.position).normalized, shootSpeed, shootPoint.position, 9, 1);

            index++;
            yield return mBullets;
        }


        yield return mWait;


    }

    IEnumerator WallOfBullets() {


        int index = 0;

        while (index < waves) {

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < width; y++) {


                    Vector3 spawnPos = shootPoint.position + (shootPoint.right * (x - (width / 2)) + (shootPoint.up * (y - (height / 2))));

                    Projectile p = Instantiate(bossBullets.PickRandom(), spawnPos, Quaternion.identity);
                    p.init((target.transform.position - shootPoint.position).normalized, shootSpeed, spawnPos, 9, 1);


                    yield return null;


                }
            }
            index++;
            yield return wWaves;
        }





        yield return wallWait;

    }




    public void ShootProjectile() {
      
        // print("WEASDSDS");
    }



}
