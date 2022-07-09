using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundMove : MonoBehaviour {

	public Sprite One;
	public Sprite Two;
	public Sprite Three;
	public Sprite Four;

	// Use this for initialization

	void Awake(){
		//this.gameObject.GetComponent<SpriteRenderer> ().sprite = One;
		this.gameObject.GetComponent<Image> ().sprite = Two;
	}

	void Start () {
		if (OptionController.IsblackBack == true) {
			//this.gameObject.GetComponent<SpriteRenderer> ().sprite = Two;
			this.gameObject.GetComponent<Image> ().sprite = Two;
		} else if (OptionController.IsredBack == true) {
			//this.gameObject.GetComponent<SpriteRenderer> ().sprite = Three;
			this.gameObject.GetComponent<Image> ().sprite = Three;
		} else if (OptionController.IsorangeBack == true) {
			//this.gameObject.GetComponent<SpriteRenderer> ().sprite = Four;
			this.gameObject.GetComponent<Image> ().sprite = Four;
		} else if (OptionController.IswhiteBack == true) {
			//this.gameObject.GetComponent<SpriteRenderer> ().sprite = One;
			this.gameObject.GetComponent<Image> ().sprite = One;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
