using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordItem : HeldItem
{


    public MeleeHitBox hitbox;
    public Animator animator;
    public int damage;
    public string text;



    public override void OnInitialSetup(ItemManager i) {
        base.OnInitialSetup(i);


        
    }

    public void ActivateHitBox() {
        hitbox.gameObject.SetActive(true);
        
    }



    public override void OnClick() {
        hitbox.damage = damage;
        animator.SetTrigger("Attack");
        OnCooldown = true;
        canSwitch = false;
    }



    public void DeactivateHitBox() {
        hitbox.gameObject.SetActive(false);
        OnCooldown = false;
        canSwitch = true;

    }



}
