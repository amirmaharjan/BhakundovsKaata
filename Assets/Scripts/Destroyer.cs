using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D coll){

		if (coll.gameObject.tag == "Obstacle") {

			// doesnt destroys the gameObject with which the script is attached
			// coll represents the gameObject with hich the collision happens
			// so it destroys that respective gameObject
			Destroy (coll.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Star") {
			Destroy (coll.gameObject);
		}
	}
		
}
