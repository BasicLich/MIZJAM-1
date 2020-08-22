using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSetter : MonoBehaviour
{

    public Toggle toggle; 


    // Start is called before the first frame update
    void Awake()
    {
        toggle.isOn = CRTPostProcess.useCRT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
