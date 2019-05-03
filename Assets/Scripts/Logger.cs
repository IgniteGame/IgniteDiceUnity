using UnityEngine;
using System.Collections;

public class Logger : MonoBehaviour {

    // bools to measure if each die has already sent its face
    static bool readyForDamage = true;
    static bool readyForTarget = true;
    static bool done = false;

    // store die results for later
    static int damageSide = -1;
    static int targetSide= -1;

    // reset bools on roll
    void Update() {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0) ) {
            // wait for 1s before ready for result of die, avoids false positives
            StartCoroutine(ResetBools() );
        }
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
            Debug.Log("Hit " + targetNames[targetSide-1] + " with a " + damageNames[damageSide - 1] + "Explosion");
            done = true;
        }
    }

}
