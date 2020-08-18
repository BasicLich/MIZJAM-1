using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBulletOnBeat : MonoBehaviour
{

    public Rigidbody bullet;
    public float force = 500f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BPeerM.beatFull) {
            Instantiate(bullet, transform.position, Quaternion.identity).AddForce(transform.forward *  force);

        }
    }
}
