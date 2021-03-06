﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Roll : MonoBehaviour {

    public float startX;

    ParticleSystem explosion;

    void Start() {
        explosion = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
    }

/*    void Update() {
        if(Input.GetKeyDown("space") || Input.GetMouseButtonDown(0) ) {
            DoRoll();
        }
        if (Input.GetKeyDown("escape") ) {
            Application.Quit();
        }
    }*/

    public void DoRoll() {
        transform.position = new Vector3(startX, 3, 0);
        transform.rotation = Random.rotation;
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 vel = new Vector3(Random.Range(-4, 4), Random.Range(-10, 5), Random.Range(-10, -8) );
        rb.velocity = vel;
        //Debug.Log(vel);
        explosion.Play();
    }

}
