using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Roll : MonoBehaviour {

    public float startX;

    void Start() {
        DoRoll();
    }

    void Update() {
        if(Input.GetKeyDown("space") || Input.GetMouseButtonDown(0) ) {
            DoRoll();
        }
        if (Input.GetKeyDown("escape") ) {
            Application.Quit();
        }
    }

    public void DoRoll() {
        transform.position = new Vector3(startX, 2, 0);
        transform.rotation = Random.rotation;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-3, 3), Random.Range(-10, 5), Random.Range(-5, 0) );
    }

}
