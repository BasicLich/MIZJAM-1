using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GhostAI ghostPrefab;
    public GroundEnemyFollowPlayer groundUnits;

    [Header("Ghosts")]
    
    public float timeInBetweenGhosts = 1f;
    public int maxGhostsAtOnce = 1;
    private int currentGhostCount = 0;
    [Header("Ground")]
    public float timeInBetweenGround = 1f;
    public int maxGroundAtOnce = 1;
    public  int currentGroundCount = 0;


    WaitForSeconds w;
    WaitForSeconds wg;
    public List<Transform> spawnSpots;
    
    public static EnemySpawner instance;


    public void GhostDied() {
        currentGhostCount--;
        
    }

    public void GroundDied() {
        currentGroundCount--;

        if (currentGroundCount < 0) {
            currentGroundCount = 0;
        }
    }

    private void Awake() {
        instance = this;
        w = new WaitForSeconds(timeInBetweenGhosts);
        wg = new WaitForSeconds(timeInBetweenGround);
    }




    public void StartSpawningGhosts() {
        StartCoroutine(SpawnGhosts());
        StartCoroutine(SpawnGroundUnits());
    }


    public IEnumerator SpawnGhosts() {


        yield return w;


        int index = 0;
        while (true) {

            if (currentGhostCount < maxGhostsAtOnce) {
                Instantiate(ghostPrefab, spawnSpots.PickRandom().position, Quaternion.identity);
                index++;
                currentGhostCount++;
            }
            yield return w;
        }


    }

    public void SwitchToBossFight() {
        maxGhostsAtOnce = 3;
        maxGroundAtOnce = 3;

    }


    public IEnumerator SpawnGroundUnits() {


        yield return wg;


        
        while (true) {

            if (currentGroundCount < maxGroundAtOnce) {
                Instantiate(groundUnits, spawnSpots.PickRandom().position, Quaternion.identity);
                
                currentGroundCount++;
            }
            yield return wg;
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
