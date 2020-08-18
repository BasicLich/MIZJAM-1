using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{


    public Image heartContainer;
    public List<Image> healthBars = new List<Image>();

    public Sprite noHeart, fullHeart;


    public int maxHP, currentHP;

    public void init(int cHP, int mHP) {


        currentHP = cHP;
        maxHP = mHP;

        foreach (Image i in healthBars) {
            if (i) Destroy(i.gameObject);
        }
        healthBars.Clear();

        for (int i = 0; i < maxHP; i++) {

            Image im = Instantiate(heartContainer, transform);
            healthBars.Add(im);

        }

        SetHealthToHP(cHP);



    }

    public void SetHealthToHP(int currentHP) {

        for (int i = 0; i < maxHP; i++) {

            if (i < currentHP) {
                healthBars[i].sprite = fullHeart;
            } else {
                healthBars[i].sprite = noHeart;
            }

        }
    }



}
