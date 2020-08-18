using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBase : MonoBehaviour
{

    public  bool canMove;
    // Start is called before the first frame update
    void Start() {
        Resume();
    }

    public void Pause() {

        canMove = false;

    }

    public void Resume() {

        canMove = true;

    }


   
}
