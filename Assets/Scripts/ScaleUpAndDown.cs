using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class ScaleUpAndDown : MonoBehaviour
{

    public Vector3 maxScale = new Vector3(2,2,2);
    public Vector3 minScale = new Vector3(.5f, .5f, .5f);
    public float timeToScaleFromCenter = 1f;

  

    bool decreasing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (decreasing) {
            transform.localScale = Vector3.MoveTowards(transform.localScale, minScale, timeToScaleFromCenter * Time.deltaTime);
            if (transform.localScale == minScale) {
                decreasing = false;
            }

        } else {

            transform.localScale = Vector3.MoveTowards(transform.localScale, maxScale, timeToScaleFromCenter * Time.deltaTime);
            if (transform.localScale == maxScale) {
                decreasing = true;
            }
        }

    }
}
