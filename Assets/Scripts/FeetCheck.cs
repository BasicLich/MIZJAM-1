using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCheck : MonoBehaviour
{

    public int groundLayer;
    public bool grounded = false;

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.layer == groundLayer) grounded = true;
    }


    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.layer == groundLayer) grounded = false;
    }



}
