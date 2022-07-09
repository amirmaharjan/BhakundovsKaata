using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

	public GameObject stars;
	public float minPos;
	public float maxPos;
	public LinkedList<GameObject> starCollection;
	public static Star instance;
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
		starCollection = new LinkedList<GameObject> ();
		//timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {
//		if (timer <= 0 && GameController.instance.gameOver == false && GameController.instance.makeStar == true) {
//			Vector3 starPos = new Vector3 (Random.Range (minPos, maxPos), transform.position.y, transform.position.z);
//			starCollection.AddFirst(Instantiate (stars, starPos, transform.rotation));
//			timer = delayTimer;
//		}

		if(this.gameObject.transform.position.y < -8){
			Destroy (this.transform.gameObject);
		}
	}

	/*private void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Ball") {
			Debug.Log ("Crossed");
			Destroy (coll.gameObject);
			GameController.instance.Crossed ();
		}
	}*/

	public void makeStar(){
		if (GameController.instance.gameOver == false) {
			Vector3 starPos = new Vector3 (Random.Range (minPos, maxPos), transform.position.y, transform.position.z);
			starCollection.AddFirst(Instantiate (stars, starPos, transform.rotation));
			Debug.Log (minPos);
			Debug.Log (maxPos);
			//timer = delayTimer;
		}
	}
}
