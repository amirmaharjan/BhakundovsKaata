using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	//public GameObject[] obstacles;

	[SerializeField]
	public GameObject[] obstacles;
	public float Obs1minPos;
	public float Obs1maxPos;
	public float Obs2minPos;
	public float Obs2maxPos;
	public float Obs3minPos;
	public float Obs3maxPos;
	public float Obs4minPos;
	public float Obs4maxPos;
	public float firstTimer = 0;
	public float delayTimer = 2f;
	float timer;
	int obsID = 1;
	public LinkedList<GameObject> collection;
	public static Obstacle instance;
	float value = 6.21f;

	// Use this for initialization
	void Start () {

		if(instance == null){
			instance = this;
		}
		collection = new LinkedList<GameObject> ();
		//timer = delayTimer;
		timer = firstTimer;
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if (timer <= 0 && GameController.instance.gameOver == false) {

			//obsNo = Random.Range(0,4);
			//Vector2 obsPos = new Vector2 (Random.Range(minPos, maxPos), transform.position.y);
			//collection.AddFirst (Instantiate (obstacles, obsPos, transform.rotation));
			if (GameController.instance.obsNo == 0) {
				Vector3 obsPos = new Vector3 (Random.Range (Obs1minPos, Obs1maxPos), value, transform.localPosition.z);
				collection.AddFirst (Instantiate (obstacles [0], obsPos, transform.rotation));
			} else if (GameController.instance.obsNo == 1) {
				Vector3 obsPos = new Vector3 (Random.Range (Obs2minPos, Obs2maxPos), value, transform.localPosition.z);
				collection.AddFirst (Instantiate (obstacles [1], obsPos, transform.rotation));
			} else if (GameController.instance.obsNo == 2) {
				Vector3 obsPos = new Vector3 (Random.Range (Obs3minPos, Obs3maxPos), value, transform.localPosition.z);
				collection.AddFirst (Instantiate (obstacles [2], obsPos, transform.rotation));
			} else if (GameController.instance.obsNo == 3) {
				Vector3 obsPos = new Vector3 (Random.Range(Obs4minPos, Obs4maxPos), value, transform.localPosition.z);
				collection.AddFirst (Instantiate (obstacles [3], obsPos, transform.rotation));
			}
			//Vector3 obsPos = new Vector3 (Random.Range(Obs4minPos, Obs4maxPos), transform.localPosition.y, transform.localPosition.z);
			//collection.AddFirst (Instantiate (obstacles [3], obsPos, transform.rotation));
			//Instantiate (obstacles[obsNo], obsPos, transform.rotation);
			if (obsID % 7 == 0) {
				Star.instance.makeStar ();
			}
			timer = delayTimer;
			obsID = obsID + 1;
			Debug.Log (obsID);
		}

		if (obsID > 10) {
			delayTimer = 1.85f;
		}

		if (obsID > 20) {
			delayTimer = 1.75f;
		}
		
	}
		
}