using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ItemManager : Unit
{
    public Transform hand;
    public HealthBar healthBar;
    public LayerMask groundLayer;
    public List<HeldItem> items =  new List<HeldItem>();
    public HeldItem currentItem = null;
    public Image reticle;
    public float killY = -5f;
    public GroundController controller;
    public Vector3 respawnOffset = new Vector3(0, 2, 0);
    public MenuController ui;
    public Transform wordBox;
    public WordBuilder wordBuilder;

    public ItemButton itemButtonPrefab;
    public List<ItemButton> buttons = new List<ItemButton>();
    public Transform buttonSpot;

    public static ItemManager instance;
    [Header("JumpBar")]
    public List<JumpIcon> jumps;
    public JumpIcon jumpIconPrefab;
    public Transform jumpSortingObject;


    private void Awake() {
        instance = this;
        healthBar.init(HP, MaxHP);
        SetText(wordBuilder.words);
    }

    public void ReactivateAllJumps() {

        controller.currentJumps = 0;
        foreach (JumpIcon j in jumps) {
            j.Activate();
        }

    }

    public void EquipItem(HeldItem h) {

        if (items.Contains(h)) {
            EquipItem(items.IndexOf(h));
        } else {
            Debug.LogError("COULD NOT FIND ITEM IN IVENTORY");
        }


    }

    public void EquipItem(int index) {

        if (currentItem != null) {
            currentItem.gameObject.SetActive(false);
        }

        currentItem = null;
        

        for (int i = 0; i < items.Count; i++) {
            if(i == index) {
                items[i].gameObject.SetActive(true);
                currentItem = items[i];
                currentItem.OnEquip(this);
            } else {
                items[i].gameObject.SetActive(false);
            }
        }




    }


    public void PickUpItem(HeldItem h) {


        h.OnInitialSetup(this);
        h.OnPickup.Invoke();
        h.transform.SetParent(hand);
        h.transform.localPosition = Vector3.zero;
        h.transform.localRotation = Quaternion.identity;
        items.Add(h);
        h.gameObject.SetActive(false);

        h.transform.GetChild(0).localPosition = h.posOffset;
        h.transform.GetChild(0).localRotation = Quaternion.Euler(h.rotationOffset);
        h.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;



        if (currentItem == null) {
            EquipItem(0);
        }

        ItemButton  i = Instantiate(itemButtonPrefab, buttonSpot);
        i.init(h.icon, h);
        buttons.Add(i);
        h.itemButton = i;

        h.OnInitialSetup(this);
        


    }


    


    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Item") {

            PickUpItem(other.GetComponent<HeldItem>());

        } else if (other.tag == "PickUp") {

            other.gameObject.GetComponent<Pickup>().OnPickup.Invoke();
            Destroy(other.gameObject);

        }

    }


    public override void OnHit() {


        healthBar.SetHealthToHP(HP);

    }


    public override void OnDeath() {

        if (!isDead) {
            StartCoroutine(Death());
        }

    }



    bool isDead = false;
    IEnumerator Death() {
        Cursor.lockState = CursorLockMode.Locked;
        isDead = true;
        controller.Pause();
        yield return new WaitForSeconds(2f);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        ui.ShowLoseScreen();


    }



    public List<Vector3> spawnOffets = new List<Vector3> {

        new Vector3(1,0,0),
        new Vector3(0,0,1),
        new Vector3(-1,0,0),
        new Vector3(0,0,-1),
        new Vector3(1,0,-1),
        new Vector3(1,0,1),
        new Vector3(-1,0,1),
        new Vector3(-1,0,-1)



    };


    private void Update() {

        if (isDead) return;

        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0 && currentItem != null && !currentItem.OnCooldown) {
            currentItem.OnClick();
        }

        if (transform.position.y < killY) {
            GoToLastGroundedPosition();
            TakeDamage(1);
           
        }


        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (items.Count > 0) {
                EquipItem(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (items.Count > 1) {
                EquipItem(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) {

           // if (wordBox.gameObject.activeInHierarchy) {

           //     Cursor.visible = false;
           //     Cursor.lockState = CursorLockMode.Locked;
           //     Time.timeScale = 1;
           //     instance.controller.canMove = true;

           //     wordBox.gameObject.SetActive(false);
          //  }


        }


    }


    public void GoToLastGroundedPosition() {
        Vector3 baseSpawnSpot = controller.lastGroundedPosition + respawnOffset;


        Vector3 offset = Vector3.zero;


        foreach (Vector3 vec in spawnOffets) {

            if (Physics.Raycast(baseSpawnSpot + vec * (0.25f), Vector3.down, 10, groundLayer)) {
                offset += vec.normalized;
            }

            Debug.DrawRay(baseSpawnSpot + vec * 0.25f, Vector3.down, Color.green, 50);

        }
        //Debug.Break();
        baseSpawnSpot += offset.normalized;


        transform.position = baseSpawnSpot;

        controller.KillVelocity();
    }


    public void SetUpJumps() {

    }

    public static void AddJump() {


        JumpIcon j = Instantiate(instance.jumpIconPrefab, instance.jumpSortingObject);
        instance.jumps.Add(j);
        instance.ReactivateAllJumps();
        instance.controller.maxJumps++;
        

    }

    public static void Heal() {

        if (instance.HP < instance.MaxHP) {
            instance.HP++;
            instance.healthBar.SetHealthToHP(instance.HP);
        }
    }


    public float textDisplayTime;


    IEnumerator CloseTextInSeconds(float secs) {

        yield return new WaitForSeconds(secs);
        instance.wordBox.gameObject.SetActive(false);

    }

    public static void SetText(string s) {
       // Cursor.visible = true;
       // Cursor.lockState = CursorLockMode.None;

       // Time.timeScale = 0;
       // instance.controller.canMove = false;
        instance.wordBox.gameObject.SetActive(true);
        instance.wordBuilder.words = s;
        instance.wordBuilder.CreateWord();
        instance.StartCoroutine(instance.CloseTextInSeconds(instance.textDisplayTime));
    }

    public void NormalSetText(string s) {
        SetText(s);
    }


}
