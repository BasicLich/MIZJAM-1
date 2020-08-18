using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardTarget : MonoBehaviour
{
    public static BillboardTarget instance;


    private void Awake() {
        instance = this;
    }


}
