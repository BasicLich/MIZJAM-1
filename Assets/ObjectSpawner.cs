using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public LayerMask groundLayer;
    private float radius;
    private void Awake() {
        radius = GetComponent<SphereCollider>().radius;
    }


    public void SpawnObjectRandomly(GameObject g) {


        Vector3 spawnSpot = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius)).normalized + new Vector3(0,4,  0);
        Instantiate(g, transform.position + spawnSpot, Quaternion.identity);

    }


    
}
