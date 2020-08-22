using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitFlash : MonoBehaviour
{
    // Start is called before the first frame update

    public float AlphaFlash = 125;
    public float decreaseTimePerSecond = 1f;
    float currFlash;
    Image img;



    private void Awake() {
        img = GetComponent<Image>();
    }

    private void Update() {
        

        if (currFlash > 0) {
            currFlash -= Time.deltaTime * decreaseTimePerSecond;
            img.color = new Color(img.color.r, img.color.g, img.color.b, currFlash / 255f);


        }

    }

    public void GetHit() {
        currFlash = AlphaFlash;
    }






}
