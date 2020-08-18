using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : Unit
{
    public Transform player;
    public float speed = 5f;
   private  Rigidbody rb;
    private float sinOffest;
    public float stopDistance = 1.5f;
    public float backAwayDistance = 2f;


    


    private void Awake() {
        rb = GetComponent<Rigidbody>();
        sinOffest = Random.Range(0, 360);
        player = GroundController.instance.transform;
        moveDirection = Random.Range(-1, 2);
        defaultColor = sprite.color;
    }

    [Header("BackAway Settings")]
    private Vector3 backAway;
    public  float backAwaySpeed = 10;
    public float backawayDecel = 2f;
    public int moveDirection;
   

    Vector3 velocity = new Vector3();
    float distance;
    private void FixedUpdate() {


        if (backAway != Vector3.zero) {
          backAway =   Vector3.MoveTowards(backAway, Vector3.zero, Time.deltaTime * backawayDecel);
        }

        distance = Vector3.Distance(transform.position, player.position);


        if (distance < backAwayDistance) {

            backAway = (transform.position - player.transform.position).normalized * backAwaySpeed;

        } else if (distance < stopDistance) {


            velocity = (player.transform.position - transform.position).normalized * (speed / 5);
            //velocity.y += 1 + (Mathf.Sin(Time.time + sinOffest));
            velocity += transform.right * moveDirection * speed/2;
           


        } else {
            velocity = (player.transform.position - transform.position).normalized * speed;
            velocity.y += 1 + (Mathf.Sin(Time.time + sinOffest));
            velocity += transform.right * (Mathf.Cos(Time.time + sinOffest));

        }

        rb.velocity = velocity + backAway;


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
