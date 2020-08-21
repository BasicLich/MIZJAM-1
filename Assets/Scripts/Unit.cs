using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Unit : MonoBehaviour
{


    public int HP = 1;
    public int MaxHP;
    public Vector3 particleSystemOffset;
    protected bool isDead;

    public void TakeDamage(int amount) {

        if (isDead) return;

        HP -= amount;
        OnHit();
        if (HP <= 0) {
            HP = 0;
            isDead = true;
            Die();
        } 

    }



    public virtual void OnHit() {

    }

    public void Die() {


        OnDeath();
    
    }


    public virtual void OnDeath() {
        Destroy(gameObject);
    }

    public void SpawnParticleSystem(GameObject prefab) {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }







    
}
