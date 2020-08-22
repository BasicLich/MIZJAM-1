using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{


    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = AudioListener.volume;   
    }

    
    public void SetVolume(float f) {
        AudioListener.volume = f;
    }

}
