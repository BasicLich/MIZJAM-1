using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLookAtPlayer : MonoBehaviour
{

    private Transform followCam;

    // Start is called before the first frame update
    void Start()
    {
        followCam = GroundController.instance.transform;
    }


    private void Update() {
        transform.LookAt(followCam);
    }


}
