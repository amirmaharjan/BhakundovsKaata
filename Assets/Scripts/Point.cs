using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D (Collider2D coll){

		/*if (coll.GetComponent<BallMovement>() != null){
			GameController.instance.Scored();
		}*/

		if (coll.gameObject.tag == "Ball") {
			//Debug.Log ("Point Earned from code point");
			GameController.instance.Scored ();
			//coll.enabled = false;
			Obstacle.instance.collection.Last.Value.GetComponent<BoxCollider2D>().enabled = false;
			Obstacle.instance.collection.RemoveLast ();
		}

	}
}
