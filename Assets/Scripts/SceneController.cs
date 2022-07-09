using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;

public class SceneController : MonoBehaviour {

	public static bool sound = true;
	Animator anim;
	private Text signInButtonText;
	private Text authStatus;
	private GameObject leaderboard;

	[SerializeField]
	GameObject soundobject;
	[SerializeField]
	GameObject loginobject;

	[SerializeField]
	List<Sprite> soundsprites;
	[SerializeField]
	List<Sprite> imagesprites;

	Image myimage;
	Image myimage2;

	public static SceneController instance;

	void Awake(){
//		sound = true;
		if(instance == null){
			instance = this;
			DontDestroyOnLoad (this.gameObject);	
		}else{
			//Destroy (this.gameObject);
		}

//		PlayGamesPlatform.Activate ();
//		OnConnectionResponse (PlayGamesPlatform.Instance.localUser.authenticated);
	}

	// Use this for initialization
	void Start () {
		myimage = soundobject.GetComponent<Image> ();
		myimage2 = loginobject.GetComponent<Image> ();
		if (sound == true) {
			myimage.sprite = soundsprites [0];
		} else {
			myimage.sprite = soundsprites[1];
		}
	
		anim = GetComponent<Animator> ();
//		Debug.Log (OptionController.Iswhite);
//		Debug.Log (OptionController.Isblack);
//		Debug.Log (OptionController.Isred);
//		Debug.Log (OptionController.Isorange);
//
//		Debug.Log (OptionController.IswhiteBack);
//		Debug.Log (OptionController.IsblackBack);
//		Debug.Log (OptionController.IsredBack);
//		Debug.Log (OptionController.IsorangeBack);
		Debug.Log (sound);

		// create client configuration
		//PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();


		PlayGamesPlatform.DebugLogEnabled = true;

		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.Activate ();

		PlayGamesPlatform.Instance.Authenticate (SignInCallback, true);

		signInButtonText = GameObject.Find ("Login").GetComponentInChildren<Text> ();
		authStatus = GameObject.Find ("Auth").GetComponent<Text> ();
		leaderboard = GameObject.Find ("LeaderBoard");
	}
	
	// Update is called once per frame
	void Update () {
//		leaderboard.SetActive (Social.localUser.authenticated);
	}

	private string GetSaveString(){
		string r = "";
		r += PlayerPrefs.GetInt("Highscore").ToString();

		return r;
	}

	private void LoadSaveString (string save){
		//string data = save;
		PlayerPrefs.SetInt ("Highscore", int.Parse(save));
	}

	// cloud saving
	private bool isSaving = false;
	public void OpenSave(bool saving){
		if (Social.localUser.authenticated) {
			isSaving = saving;
			((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution ("Ball Control", 
				GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, SavedGameOpened);
		}
	}

	private void SavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata meta){
		if (status == SavedGameRequestStatus.Success) {
			if (isSaving) { // saving
				byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(GetSaveString());
				SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder ().WithUpdatedDescription ("Saved at " + DateTime.Now.ToString()).Build();

				((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta,update, data, SaveUpdate); 
			} else { // reading
				((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, SaveRead);
			}
		}
	}

	// load
	private void SaveRead (SavedGameRequestStatus status, byte[] data){
		if (status == SavedGameRequestStatus.Success) {
			string saveData = System.Text.ASCIIEncoding.ASCII.GetString (data);
			LoadSaveString (saveData);
		}
	}

	// success save
	private void SaveUpdate(SavedGameRequestStatus status, ISavedGameMetadata meta){
		
	}

	public void SignIn(){
		if (!PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.Authenticate (SignInCallback, false);
		} else {
			PlayGamesPlatform.Instance.SignOut ();
			myimage2.sprite = imagesprites [0];
			//signInButtonText.text = "Sign in";
			authStatus.text = "";
		}
	}

	public void SignInCallback(bool success){
		if (success) {
			myimage2.sprite = imagesprites [1];
			//signInButtonText.text = "Sign Out";
			authStatus.text = "User: " + Social.localUser.userName;
			OpenSave (false);
		} else {
			myimage2.sprite = imagesprites [0];
			//signInButtonText.text = "Sign in";
			authStatus.text = "";
		}
	}

	public void SignInCallLeaderboard(bool success){
		if (success) {
			myimage2.sprite = imagesprites [1];
			authStatus.text = "User: " + Social.localUser.userName;
			PlayGamesPlatform.Instance.ShowLeaderboardUI ();
		}
	}

//	public void ShowLeaderboards(){
//		if (PlayGamesPlatform.Instance.localUser.authenticated) {
//			PlayGamesPlatform.Instance.ShowLeaderboardUI ();
//		}
//	}

	public void ShowLeaderboards(){
		if (!PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.Authenticate (SignInCallLeaderboard, false);
		}else if (PlayGamesPlatform.Instance.localUser.authenticated){
			PlayGamesPlatform.Instance.ShowLeaderboardUI ();
		}
	}

	public void SoundOff(){
		sound = !sound;
		if (sound) {
			//soundobject.GetComponent<Animator> ().SetBool ("Sound", true);
			myimage.sprite = soundsprites[0];
			AudioListener.volume = 1f;
			Debug.Log ("code true");
		} else {
			//soundobject.GetComponent<Animator> ().SetBool ("Sound", false);
			myimage.sprite = soundsprites[1];
			AudioListener.volume = 0f;
			Debug.Log ("code false");
		}
	}
//
//	public void SoundOn(){
//		AudioListener.volume = 1f;
//	}

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

//		if (OptionController.Isred == true) {
//			OptionController.Isred = true;
//		} else {
//			OptionController.Isred = false;
//		}
//
//		if (OptionController.Iswhite == true) {
//			OptionController.Iswhite = true;
//		} else {
//			OptionController.Iswhite = false;
//		}
//
//		if (OptionController.Isblack == true) {
//			OptionController.Isblack = true;
//		} else {
//			OptionController.Isblack = false;
//		}
//
//		if (OptionController.Isorange == true) {
//			OptionController.Isorange = true;
//		} else {
//			OptionController.Isorange = false;
//		}
//
//		if (OptionController.IswhiteBack == true) {
//			OptionController.IswhiteBack = true;
//		} else {
//			OptionController.IswhiteBack = false;
//		}
//
//		if (OptionController.IsblackBack == true) {
//			OptionController.IsblackBack = true;
//		} else {
//			OptionController.IsblackBack = false;
//		}
//
//		if (OptionController.IsredBack == true) {
//			OptionController.IsredBack = true;
//		} else {
//			OptionController.IsredBack = false;
//		}
//
//		if (OptionController.IsorangeBack == true) {
//			OptionController.IsorangeBack = true;
//		} else {
//			OptionController.IsorangeBack = false;
//		}

//		OptionController.Iswhite = false;
//		OptionController.Isblack = false;
//		OptionController.Isred = false;
//		OptionController.Isorange = false;
//		OptionController.IswhiteBack = false;
//		OptionController.IsblackBack = false;
//		OptionController.IsredBack = false;
//		OptionController.IsorangeBack = false;
	}

	public void Exit(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		Application.Quit ();
	}

}
