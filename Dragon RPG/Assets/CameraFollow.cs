﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        transform.position = player.gameObject.transform.position;
    }
}
