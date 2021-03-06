﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Logger : MonoBehaviour {

    // bools to measure if each die has already sent its face
    static bool readyForDamage = true;
    static bool readyForTarget = true;
    static bool done = false;

    // store die results for later
    static int damageSide = -1;
    static int targetSide= -1;

    static Text text;

    void Start() {
        text = (Text) GameObject.Find("Text").GetComponent<Text>();
        text.text = "";
    }

    // reset bools on roll
    public void OnRoll() {
        // wait for 1s before ready for result of die, avoids false positives
        StartCoroutine(ResetBools() );
        text.text = "";
    }

    IEnumerator ResetBools() {
        yield return new WaitForSeconds(1);
        readyForDamage = true;
        readyForTarget = true;
        done = false;
    }

    // names of faces
    static string[] damageNames = { "Medium", "Small", "Large", "Large", "Small", "Medium" };
    static string[] targetNames = { "Forge", "Slot 4", "Slot 2", "Slot 3", "Slot 1", "Forge" };



    public static void Log(int side, string dieName) {
        if(dieName=="Damage" && readyForDamage) {
            damageSide = side;
            readyForDamage = false;
        }
        else if (dieName == "Target" && readyForTarget) {
            targetSide = side;
            readyForTarget = false;
        }

        if(!readyForDamage && !readyForTarget && !done) { // both values recieved and haven't done this for this roll
            text.text = "Hit " + targetNames[targetSide-1] + " with a " + damageNames[damageSide - 1] + " Explosion";
            done = true;
        }
    }

}
