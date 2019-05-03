using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
    }
    void Update() {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0) ) {
            audio.Play(0);
        }
    }
}
