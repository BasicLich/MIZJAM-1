using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitBox : MonoBehaviour
{

    public int enemyLayer = 10;
    public int damage;
    
    private void OnTriggerEnter(Collider other) {

      
        if (other.gameObject.layer == enemyLayer) {
            
            other.GetComponent<Unit>().TakeDamage(damage);
            if (other.GetComponent<Unit>().HP <= 0) {

                if (Random.Range(0, 1f) > 0.5f) {
                    ItemManager.Heal();
                }
            }

        }

    }

}
