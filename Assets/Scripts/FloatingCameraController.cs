using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCameraController : ControllerBase
{


    public float RotateSpeed = 180f;
    public float MoveSpeed = 5f;
    public float rotXRange = 75f;
    

    public float rotX, rotY;


  

    // Update is called once per frame
    void Update()
    {

        if (!canMove) return;

        

        transform.Translate(Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime, 0,  Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime);
        transform.position += new Vector3(0, Input.GetAxis("UPDOWN") * MoveSpeed * Time.deltaTime, 0);
        rotY += Input.GetAxis("Mouse X") * RotateSpeed * Time.deltaTime;
        rotX += -Input.GetAxis("Mouse Y") * RotateSpeed * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -rotXRange, rotXRange);

        transform.eulerAngles = new Vector3(rotX, rotY, 0);

    }
}
