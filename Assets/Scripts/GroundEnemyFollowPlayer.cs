using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyFollowPlayer : Unit
{

    NavMeshAgent nav;
    Transform follow;
    public bool active;
    public bool dropsItem = true;
    public MeleeHitBox hitBox;
    public float timeInBetweenAttacks =  1f, attackUpTime = 0.25f, attackWindUp = 0.25f;
    public float playerDistance = 2f;


    WaitForSeconds attackTime, windUp, uptime;

    private void Start() {
        nav = GetComponent<NavMeshAgent>();
        follow = GroundController.instance.transform;
        defaultColor = sprite.color;
        attackTime = new WaitForSeconds(timeInBetweenAttacks);
        windUp = new WaitForSeconds(attackWindUp);
        uptime = new WaitForSeconds(attackUpTime);
        
    }

    bool canAttack = true;

    private void Update() {
        if (canAttack && active) {

            if (Vector3.Distance(follow.position, transform.position) < playerDistance) {
                nav.isStopped = true;
                StartCoroutine(Attack());
            }

            nav.SetDestination(follow.position);
        }
        SplashCheck();
    }

    IEnumerator Attack() {

        canAttack = false;
        yield return windUp;
        hitBox.gameObject.SetActive(true);
        yield return uptime;
        hitBox.gameObject.SetActive(false);
        yield return attackTime;
        canAttack = true;
        nav.isStopped = false;

    } 


    public override void OnHit() {
        base.OnHit();
        StartSplash();
    }

    public override void OnDeath() {


        EnemySpawner.instance.GroundDied();
        if (BossBar.instance)BossBar.instance.EnemyDied();

        if (dropsItem && Random.Range(0f, 1f) < 0.8f) {
            PickupAndItemSpawner.instance.SpawnRandomItem(transform.position);
        }
        base.OnDeath();



    }


    [Header("Splash Settings")]
    public SpriteRenderer sprite;
    public Color Damage;
    private Color defaultColor;
    public float splashLength;
    private float splashCounter;


    public void StartSplash() {
        sprite.color = Damage;
        splashCounter = splashLength;
    }

    public void SplashCheck() {
        if (splashCounter > 0) {
            splashCounter -= Time.deltaTime;
            if (splashCounter <= 0) {
                sprite.color = defaultColor;
            }
        }
    }



}
