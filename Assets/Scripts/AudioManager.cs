using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    AudioSource audio;

    private bool isMuted = false;

    void Start() {
        audio = GetComponent<AudioSource>();
    }
    void Update() {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0) ) {
            if(!isMuted) {
                audio.Play(0);
            }
        }
    }

    public void Mute() {
        isMuted = true;
    }

}
