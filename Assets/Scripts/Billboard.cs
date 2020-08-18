using UnityEngine;

public class Billboard : MonoBehaviour {




    private void Awake() {

        BillBoardManager.billBoards.Add(this);
        //print("????");
    }



    private void OnDestroy() {
        BillBoardManager.billBoards.Remove(this);
    }




}