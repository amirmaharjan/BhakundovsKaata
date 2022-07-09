using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour {

	// Use this for initialization
	public static bool iswhite;
	public static bool isblack;
	public static bool isred;
	public static bool isorange;
	public static bool iswhiteBack;
	public static bool isblackBack;
	public static bool isredBack;
	public static bool isorangeBack;
	public static OptionController instance;

	public static bool Iswhite {
		get {
			return iswhite;
		}
		set {
			iswhite = value;
		}
	}

	public static bool Isblack {
		get {
			return isblack;
		}
		set {
			isblack = value;
		}
	}

	public static bool Isred {
		get {
			return isred;
		}
		set {
			isred = value;
		}
	}

	public static bool Isorange {
		get {
			return isorange;
		}
		set {
			isorange = value;
		}
	}

	public static bool IswhiteBack{
		get{ 
			return iswhiteBack;
		}
		set{ 
			iswhiteBack = value;
		}
	}

	public static bool IsblackBack{
		get{ 
			return isblackBack;
		}
		set{ 
			isblackBack = value;
		}
	}

	public static bool IsredBack{
		get{ 
			return isredBack;
		}
		set{ 
			isredBack = value;
		}
	}

	public static bool IsorangeBack{
		get{ 
			return isorangeBack;
		}
		set{ 
			isorangeBack = value;
		}
	}

	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void Start () {
		Debug.Log (iswhite);
		Debug.Log (isblack);
		Debug.Log (isred);
		Debug.Log (isorange);

		Debug.Log (iswhiteBack);
		Debug.Log (isblackBack);
		Debug.Log (isredBack);
		Debug.Log (isorangeBack);

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Back(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		SceneManager.LoadScene ("Menu");
	}

	public void ChooseWhite(){
//		iswhite = true;
		FindObjectOfType<AudioManager> ().Play ("Touch");
		OptionController.Iswhite = true;
		OptionController.Isblack = false;
		OptionController.Isred = false;
		OptionController.Isorange = false;
		Debug.Log (iswhite);
	}

	public void ChooseBlack(){
//		isblack = true;
		FindObjectOfType<AudioManager> ().Play ("Touch");
		OptionController.Iswhite = false;
		OptionController.Isblack = true;
		OptionController.Isred = false;
		OptionController.Isorange = false;
		Debug.Log (isblack);
	}

	public void ChooseRed(){
//		isred = true;
		FindObjectOfType<AudioManager> ().Play ("Touch");
		OptionController.Iswhite = false;
		OptionController.Isblack = false;
		OptionController.Isred = true;
		OptionController.Isorange = false;
		Debug.Log (isred);
	}

	public void ChooseOrange(){
//		isorange = true;
		FindObjectOfType<AudioManager> ().Play ("Touch");
		OptionController.Iswhite = false;
		OptionController.Isblack = false;
		OptionController.Isred = false;
		OptionController.Isorange = true;
		Debug.Log (isorange);
	}
	public void ChooseWhiteBack(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		OptionController.IswhiteBack = true;
		OptionController.IsblackBack = false;
		OptionController.IsredBack = false;
		OptionController.IsorangeBack = false;
		Debug.Log (iswhiteBack);
	}

	public void ChooseBlackBack(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		OptionController.IswhiteBack = false;
		OptionController.IsblackBack = true;
		OptionController.IsredBack = false;
		OptionController.IsorangeBack = false;
		Debug.Log (isblackBack);
	}

	public void ChooseRedBack(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		OptionController.IswhiteBack = false;
		OptionController.IsblackBack = false;
		OptionController.IsredBack = true;
		OptionController.IsorangeBack = false;
		Debug.Log (isredBack);
	}

	public void ChooseOrangeBack(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		OptionController.IswhiteBack = false;
		OptionController.IsblackBack = false;
		OptionController.IsredBack = false;
		OptionController.IsorangeBack = true;
		Debug.Log (isorangeBack);
	}
}
