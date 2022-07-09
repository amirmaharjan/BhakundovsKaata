using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Back(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		SceneManager.LoadScene ("Menu");
	}
}
