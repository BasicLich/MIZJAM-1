


using UnityEngine;
using UnityEngine.UI;

public class JumpIcon : MonoBehaviour {

    public Image jumpIcon;

    public Sprite full, empty;
    


    public void Activate() {
        jumpIcon.sprite = full;
    }

    public void Deactivate() {
        jumpIcon.sprite = empty;
    }



}