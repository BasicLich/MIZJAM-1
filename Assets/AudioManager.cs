using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public List<AudioSource> sources;
    public int currentTrack;
    public float fadeSpeed = 1;
    // Start is called before the first frame update

    private void Awake() {
        instance = this;
    }

    public void PlayTrack(int x) {
        
        StartCoroutine(FadeMusic(instance.sources[instance.currentTrack], instance.sources[x]));

        instance.currentTrack = x;
    }

    public IEnumerator FadeMusic(AudioSource current, AudioSource target) {

        float musicVolume = 1;

        target.volume = 0;
        target.Play();

        while (musicVolume > 0) {


            musicVolume -= (1/fadeSpeed) * Time.deltaTime;
            musicVolume = Mathf.Max(0, musicVolume);
            current.volume = musicVolume;
            target.volume = 1 - musicVolume;
            yield return null;

        }

        current.Stop();
        

    }

    internal void Pause() {
        sources[currentTrack].Pause();
    }

    public void Resume() {
        sources[currentTrack].UnPause();
    }
}
