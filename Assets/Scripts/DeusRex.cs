using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeusRex : Unit
{

    Transform target;



    private void Start() {
        target = GroundController.instance.transform;
    }


    private void Update() {
        transform.LookAt(target);
    }



}
