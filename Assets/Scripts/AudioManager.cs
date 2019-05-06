using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    AudioSource audio;
    Image volumeImage;
    public Sprite volumeOnSprite;
    public Sprite volumeOffSprite;

    private bool isMuted = false;

    void Start() {
        audio = GetComponent<AudioSource>();
        GameObject volumeButton = GameObject.Find("VolumeButton");
        volumeImage = volumeButton.GetComponent<Image>();

        if(PlayerPrefs.GetInt("Volume")==0) {
            Mute();
        }
    }

    public void PlayAudio() {
        if(!isMuted) {
            audio.Play(0);
        }
    }

    public void ToggleMute() {
        if(!isMuted) {
            Mute();
        } else {
            Unmute();
        }
    }

    void Mute() {
        isMuted = true;
        volumeImage.sprite = volumeOffSprite;
        PlayerPrefs.SetInt("Volume", 0);
    }

    void Unmute() {
        isMuted = false;
        volumeImage.sprite = volumeOnSprite;
        PlayerPrefs.SetInt("Volume", 1);
    }

}
