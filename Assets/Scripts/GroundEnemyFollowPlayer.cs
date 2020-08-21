using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyFollowPlayer : Unit
{

    NavMeshAgent nav;
    Transform follow;
    public bool active;
    


    private void Start() {
        nav = GetComponent<NavMeshAgent>();
        follow = GroundController.instance.transform;
        defaultColor = sprite.color;
    }



    private void Update() {
        if (active) {
            nav.SetDestination(follow.position);
        }
        SplashCheck();
    }


    public override void OnHit() {
        base.OnHit();
        StartSplash();
    }

    public override void OnDeath() {


        EnemySpawner.instance.GroundDied();
        if (BossBar.instance)BossBar.instance.EnemyDied();

        if (Random.Range(0f, 1f) > 0.5f) {
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
