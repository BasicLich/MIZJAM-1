using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCheck : MonoBehaviour
{

    public int groundLayer;
    public int numberOfThings = 0;
    public bool grounded = false;

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.layer == groundLayer) {
           
            numberOfThings++;
            grounded = true;
            
        }
    }


    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.layer == groundLayer) {
            numberOfThings--;
            if (numberOfThings <= 0) {
                numberOfThings = 0;
                grounded = false;
            }
        }
    }



}
