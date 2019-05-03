using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

    bool validInput = true;

    public GameObject targetDie;
    public GameObject damageDie;

    Roll targetDieRollScript;
    Roll damageDieRollScript;

    AudioManager audioManagerScript;

    void Start() {
        //targetDieRollScript = (Roll) GameObject.Find("TargetDie").GetComponent(typeof(Roll) );
        //damageDieRollScript = (Roll)GameObject.Find("DamageDie").GetComponent(typeof(Roll) );

        targetDieRollScript = (Roll) targetDie.GetComponent(typeof(Roll));
        damageDieRollScript = (Roll) damageDie.GetComponent(typeof(Roll) );

        audioManagerScript = GetComponent<AudioManager>();

    }

    void HandleRolls() {
        targetDieRollScript.DoRoll();
        damageDieRollScript.DoRoll();
        audioManagerScript.PlayAudio();
    }

    void Update() {
        if (Input.GetKeyDown("escape") ) {
            Application.Quit();
        }

        // https://stackoverflow.com/questions/38198745/how-to-detect-left-mouse-click-but-not-when-the-click-occur-on-a-ui-button-compo
        // roll if clicking and not clicking on a canvas button
        validateInput();

        #if UNITY_STANDALONE || UNITY_EDITOR
        // Desktop
        if ( (Input.GetMouseButtonUp(0) && validInput) || Input.GetKeyDown("space") ) {
            HandleRolls();
        }
        #else
        // Mobile
        if ( (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && validInput) || Input.GetKeyDown("space") ) {
            HandleRolls();
        }
        #endif
    }

    void validateInput() {
        #if UNITY_STANDALONE || UNITY_EDITOR
            //DESKTOP COMPUTERS
            if (Input.GetMouseButtonDown(0) ) {
                if (EventSystem.current.IsPointerOverGameObject() )
                    validInput = false;
                else
                    validInput = true;
            }
        #else
            //MOBILE DEVICES
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) )
                    validInput = false;
                else
                    validInput = true;
            }
        #endif
    
    }
}
