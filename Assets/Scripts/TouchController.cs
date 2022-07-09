using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		/*if (Input.touchCount > 0) {
			BallMovement.instance.rb.gravityScale = 1.5f;
			BallMovement.instance.TouchMove ();
		}*/

		/*if (GameController.instance.regame == true && Input.GetMouseButtonDown (0)) {
			//Time.timeScale = 1;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}else if (GameController.instance.regame == true && Input.touchCount > 0) {
			//Time.timeScale = 1;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}*/
	}

	void Restart(){
		if (GameController.instance.regame == true && Input.GetMouseButtonDown (0)) {
			//Time.timeScale = 1;
		FindObjectOfType<AudioManager> ().Play ("Touch");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}else if (GameController.instance.regame == true && Input.touchCount > 0) {
			//Time.timeScale = 1;
		FindObjectOfType<AudioManager> ().Play ("Touch");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

}
