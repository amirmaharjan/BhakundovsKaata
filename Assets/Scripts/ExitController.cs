﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Exit(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		Application.Quit ();
	}
}
