using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{

    public Transform point;
    public float speed = 180;


    private void Update() {


        transform.RotateAround(point.position, new Vector3(0, 1, 0), speed * Time.deltaTime);

    }


}
