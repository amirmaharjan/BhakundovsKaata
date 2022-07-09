using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObs : MonoBehaviour {

	public static MoveObs instance;
	public float speed = 2f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	public void Update () {

		if(GameController.instance.gameOver == false){
			//Debug.Log ("Moving obs");
			transform.Translate (new Vector3 (0, -1, 0) * speed * Time.deltaTime);
		
		//transform.Translate (new Vector3 (Random.Range(-1, 2), -1, 0) * speed * Time.deltaTime);
		//transform.Translate (new Vector3 (Random.Range(-2, 3), -1, 0) * speed * Time.deltaTime);
		}

		//transform.Translate (new Vector3 (0, -1, 0) * speed * Time.deltaTime);
		if(this.gameObject.transform.position.y < -8){
			Destroy (this.transform.gameObject);
		}
	}
		

}
