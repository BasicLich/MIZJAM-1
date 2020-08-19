using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupAndItemSpawner : MonoBehaviour
{

    public List<Pickup> pickups = new List<Pickup>();
    public List<HeldItem> items = new List<HeldItem>();


    public void SpawnItem(int id, Vector3 pos, Vector3 rot) {

        HeldItem i = Instantiate(items[id], pos, Quaternion.Euler(rot));


    }


    public void SpawnGun(Transform t) {
        SpawnItem(1, t.position + Vector3.up, t.rotation.eulerAngles);
    }


}
