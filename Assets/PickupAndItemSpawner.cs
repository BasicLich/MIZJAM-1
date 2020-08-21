using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupAndItemSpawner : MonoBehaviour
{

    public List<ObjectSpawner> spawner = new List<ObjectSpawner>();
    public List<GameObject> items = new List<GameObject>();
    public static PickupAndItemSpawner instance;

    private void Awake() {
        instance = this;
    }


    public void SpawnItem(int id, Vector3 pos, Vector3 rot) {

        Instantiate(items[id], pos, Quaternion.Euler(rot));


    }


    public void SpawnGun(Transform t) {
        SpawnItem(1, t.position + Vector3.up, t.rotation.eulerAngles);
    }

    public void SpawnRandomItem(Vector3 pos) {
        SpawnItem(Random.Range(0, items.Count), pos + (Vector3.up * 2), Vector3.zero);
    }


}
