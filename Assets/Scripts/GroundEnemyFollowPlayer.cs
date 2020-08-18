using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyFollowPlayer : Unit
{

    NavMeshAgent nav;
    Transform follow;

    


    private void Start() {
        nav = GetComponent<NavMeshAgent>();
        follow = GroundController.instance.transform;
        defaultColor = sprite.color;
    }



    private void Update() {
        nav.SetDestination(follow.position);
        SplashCheck();
    }


    public override void OnHit() {
        base.OnHit();
        StartSplash();
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
