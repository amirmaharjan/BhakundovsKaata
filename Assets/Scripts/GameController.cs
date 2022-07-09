using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;

public class GameController : MonoBehaviour {

	// creating a static instance of the respective class GameController
	// so we can easily access it from other scripts
	public static GameController instance;
	public GameObject gameOverText;
	public GameObject Home;
	public GameObject RestartText;
	public GameObject EndScore;
	public GameObject Image;
	public GameObject obstacle;
	public GameObject star;
	// checking whether the gameOver is true or false
	public bool gameOver = false;
	public bool regame = false;
	public Text scoreText;
	public Text highscoreText;
	public Text endScore;
	public bool makeStar;
	private int score = 0;
	public int obsNo = 0;
	//public bool iswhite;
	//public bool isblack;
	//int counter;

	void Awake() {
		if (instance == null) {
			instance = this;
		}else if (instance != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		//Debug.Log (iswhite);
		highscoreText.text = "Highscore: " + (PlayerPrefs.GetInt ("Highscore").ToString());
	}
	
	// Update is called once per frame
	void Update () {

		/*if (regame == true && Input.GetButtonDown ("JumpUp")) {
			//Time.timeScale = 1;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}else if (regame == true && Input.touchCount > 0) {
			//Time.timeScale = 1;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}*/

	}

	public void Restart(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		Debug.Log ("The game will RE");

	}

	public void Play(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		SceneManager.LoadScene ("MainGame");
	}

	public void Back(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		SceneManager.LoadScene ("Menu");
	}

	public void HowToPlay(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		SceneManager.LoadScene ("HowToPlay");
	}

	public void Option(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		SceneManager.LoadScene ("Option");
	}

	/*public void ChooseWhite(){
		iswhite = true;
	}

	public void ChooseBlack(){
		isblack = true;
		Debug.Log ("Black Selected");
	}*/

	public void Scored(){

		if (gameOver) {
			return;
		}
		score++;
		scoreText.text = "Score: " + score.ToString ();
//		if (score % 5 == 0) {
//			Star.instance.makeStar ();
//		}

		if (score % 7 == 0) {
			obsNo = obsNo + 1;
			if (obsNo > 3) {
				obsNo = 0;
			}
		}

	}

	public void Crossed(){
		
	}

	public void GameOver() {
		// enables the disabled gameObject
//		if (!increase){
//			int no = counter++;
//			increase = true;
//		}
		//AdController.counter++;

		AdController.counter++;
		Debug.Log ("Counter value is" + AdController.counter);
		gameOverText.SetActive (true);
		Home.SetActive (true);
		RestartText.SetActive (true);
		EndScore.SetActive (true);
		Image.SetActive (true);
		//endScore.text = ((int)score).ToString ();
		endScore.text = "Score: " + score.ToString();
		//gameOver = true;
		if (PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.ReportScore (score, BCGPGSIds.leaderboard_ball_control,(bool success) => {
			});
		}
		if (PlayerPrefs.GetInt ("Highscore") < score) {
			PlayerPrefs.SetInt ("Highscore", score);
			if (PlayGamesPlatform.Instance.localUser.authenticated) {
				SceneController.instance.OpenSave (true);
			}
		}
		obstacle.SetActive (false);
		star.SetActive (false);
		if(AdController.counter%3== 0){
			AdController.instance.showAd ();
		}
	}
}
