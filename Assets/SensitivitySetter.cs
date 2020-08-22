using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySetter : MonoBehaviour
{

    public Slider slider;
    


    private void Awake() {
        slider.value = GroundController.sensitivity;
    }
}
