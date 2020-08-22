using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupAndItemSpawner : MonoBehaviour
{

    public List<ObjectSpawner> spawner = new List<ObjectSpawner>();
    public List<GameObject> items = new List<GameObject>();
    public static PickupAndItemSpawner instance;
    public float pickupTime;


    WaitForSeconds w;

    private void Awake() {
        instance = this;
        w = new WaitForSeconds(pickupTime);
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



    public void SpawnRandomPickupsRoutine() {
        StartCoroutine(SpawnStuff());
    }

    public IEnumerator SpawnStuff() {


        yield return w;


        while (true) {
            SpawnRandomItem(spawner.PickRandom().transform.position);
            yield return w;
        }





    }


}
