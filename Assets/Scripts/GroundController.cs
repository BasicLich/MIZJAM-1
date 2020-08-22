using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GroundController : ControllerBase {


    public static GroundController instance;

    private float mouseXInput, mouseYInput;
    [SerializeField] private float mouseXSpeed = 60, mouseYSpeed = -60, walkSpeed = 5f;
    [SerializeField] public GameObject cam;


    public ItemManager itemManager;


    private Rigidbody rigidBody;
    Vector3 velocity;
    public Vector3 lastGroundedPosition;

    [Header("Shooting")]
    public Transform aimPoint;

    [Header("Jumping")]
    public FeetCheck feetCheck;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform jumpPoint;
    [SerializeField] public int maxJumps = 0;
    [SerializeField] private float jumpSpeed = 8f;
    public int currentJumps = 0;
    bool grounded = false;
    bool prevGrounded = false;
    bool timetillNextCheck;
    public Animator animator;

    
    

    private float inputHorizontal, inputVertical;


    public void KillVelocity() {
        rigidBody.velocity = Vector3.zero;
        velocity = Vector3.zero;
        currentAirDash = Vector3.zero;
    }

    public void GetInputs() {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
    }


    private void Awake() {
        instance = this;
        SetSensitivty(sensitivity);
    }

    // Start is called before the first frame update
    void Start() {
        
        rigidBody = GetComponent<Rigidbody>();
        Resume();
        
    }

    float jumpcdTimer;
    float cantjumpAfterJump = 0.5f;
    public float angleRange = 60f;

    float camX;
    // Update is called once per frame
    void Update() {

        if (!canMove) return;
        GetInputs();
        //print("Raw: " + Input.GetAxisRaw("Horizontal") + " Normal: " + Input.GetAxis("Horizontal"));

        mouseXInput = Input.GetAxis("Mouse X");
        mouseYInput = Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouseXInput * Time.deltaTime * mouseXSpeed, 0);
        camX += mouseYInput * Time.deltaTime * mouseYSpeed;
        camX = Mathf.Clamp(camX, -angleRange, angleRange);

        cam.transform.localEulerAngles = new Vector3(camX, 0, 0);






        velocity = cam.transform.forward * inputVertical +
                   cam.transform.right * inputHorizontal;



        velocity.y = 0;
        velocity = velocity * walkSpeed;
        velocity.y = rigidBody.velocity.y;

      //  if (jumpcdTimer > 0) {
       //     grounded = false;
       //     jumpcdTimer -= Time.deltaTime;
       // } else {
            grounded = feetCheck.grounded;
       // }

        if (grounded && !prevGrounded) {
            itemManager.ReactivateAllJumps();
            currentAirDash = Vector3.zero;
            
        }

        if (grounded) {
            lastGroundedPosition = transform.position;
        }


        if (Input.GetKeyDown(KeyCode.Space)) {

            if (maxJumps != 0 && (grounded || (!grounded && currentJumps < maxJumps))) {

                velocity.y = jumpSpeed;
                itemManager.jumps[itemManager.jumps.Count - currentJumps - 1].Deactivate();
                currentJumps++;

                

                

            }

        }



        if (currentAirDash != Vector3.zero) {
            currentAirDash = Vector3.MoveTowards(currentAirDash, Vector3.zero, airdashDecel * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !grounded && currentAirDash == Vector3.zero) {


            //currentAirDash = (cam.transform.forward);
            currentAirDash = cam.transform.forward * inputVertical +
            cam.transform.right * inputHorizontal;
            currentAirDash.y = 0;
            if (currentAirDash == Vector3.zero) {
                currentAirDash = (cam.transform.forward);
            }

            currentAirDash.y = 0;
            currentAirDash.Normalize();
            currentAirDash *= airDashSpeed;

        }

        velocity = velocity + currentAirDash;
        if (velocity.magnitude > 0.2f) {
            animator.SetBool("Walk", true);
        } else {
            animator.SetBool("Walk", false);
        }

        rigidBody.velocity = velocity;

        prevGrounded = grounded;



    }


    Vector3 currentAirDash;
    public float airDashSpeed = 6;
    public float airdashDecel = 2f;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Death") {
            transform.position = new Vector3(0, 10, 0);

        }
    }


    public static float sensitivity = .5f;

    public void SetSensitivty(float amt) {

        sensitivity = amt;
        mouseXSpeed = 360 * amt;
        mouseYSpeed = -360 * amt;


    }







}