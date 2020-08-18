


using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

    public Image img;
    


    public void init(Sprite s, HeldItem h) {
        img.sprite = s;
    }

}