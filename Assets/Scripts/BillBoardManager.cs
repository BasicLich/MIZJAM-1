using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardManager : MonoBehaviour
{
    public static List<Billboard> billBoards = new List<Billboard>();
    public Transform target;


    private void Start() {
        
        target = BillboardTarget.instance.transform;
    }

    int i = 0;

    private void Update() {
        for (int i = 0; i < billBoards.Count; i++) {
            billBoards[i].transform.forward = target.forward;
        }
    }





}
