using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDestroyEvent : MonoBehaviour
{


    public UnityEvent onDes;


    private void OnDestroy() {
        onDes.Invoke();
    }

}
