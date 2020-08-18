using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BPeerM : MonoBehaviour
{



    private static BPeerM instance;
    public float bpm;
    private float beatInterval, beatTimer;
    public static int beatCountFull;
    public static bool beatFull;
    public AudioSource timeSamples;



    private void Awake() {
        if (instance == null && instance != this)
        instance = this;
        else {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BeatDetection();
        print(timeSamples.timeSamples);
    }


    void BeatDetection() {

        beatFull = false;
        beatInterval = 60 / bpm;
        beatTimer += Time.deltaTime;
        if (beatTimer >= beatInterval) {
            beatTimer -= beatInterval;
            beatFull = true;
            beatCountFull++;
        }

    }

}
