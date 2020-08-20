using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    float speed;
    Vector3 targetDirection;
    Vector3 aimPoint;
    private bool adjustedYet;
    int targetLayer  = 10;
    int damage;
    public Rigidbody rb;

    public void init(Vector3 direction, float spd, Vector3 aPoint, int tLayer, int d) {

        targetDirection = direction;
        speed = spd;
        adjustedYet = false;
        aimPoint = aPoint;
        transform.forward = direction;
        targetLayer = tLayer;
        damage = d;
        rb.constraints = RigidbodyConstraints.FreezeAll;

    }




    private void Update() {
        

        if (adjustedYet) {
            rb.velocity = targetDirection * speed;
            
        } else {
            transform.position = Vector3.MoveTowards(transform.position, aimPoint, Time.deltaTime * speed);
            if (transform.position == aimPoint) {
                adjustedYet = true;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }

    }



  //  private void OnTriggerEnter(Collider other) {


        
   // }

    private void OnCollisionEnter(Collision other) {

        if (other.gameObject.layer == targetLayer) {
            print("Doing Damage " + damage);
            other.gameObject.GetComponent<Unit>().TakeDamage(damage);

        }
        Destroy(gameObject);
    }












}
