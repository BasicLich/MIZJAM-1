using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GhostAI ghostPrefab;

    public int numGhosts = 20;
    public float timeInBetweenGhosts = 1f;
    WaitForSeconds w;
    public List<Transform> spawnSpots;
    public int maxGhostsAtOnce = 1;
    private int currentGhostCount = 0;
    public static GhostSpawner instance;


    public void GhostDied() {
        currentGhostCount--;
    }

    private void Awake() {
        instance = this;
        w = new WaitForSeconds(timeInBetweenGhosts);
    }




    public void StartSpawningGhosts() {
        StartCoroutine(SpawnGhosts());
    }


    public IEnumerator SpawnGhosts() {


        yield return w;


        int index = 0;
        while (index < numGhosts) {

            if (currentGhostCount < maxGhostsAtOnce) {
                Instantiate(ghostPrefab, spawnSpots.PickRandom().position, Quaternion.identity);
                index++;
                currentGhostCount++;
            }
            yield return w;
        }


    }



}



public static class EnumerableExtension {
    public static T PickRandom<T>(this IEnumerable<T> source) {
        return source.PickRandom(1).Single();
    }

    public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count) {
        return source.Shuffle().Take(count);
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) {
        return source.OrderBy(x => Guid.NewGuid());
    }
}
