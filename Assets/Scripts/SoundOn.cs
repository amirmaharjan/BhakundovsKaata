using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOn : StateMachineBehaviour {

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		AudioListener.volume = 0.8f;
		Debug.Log ("Sound On");
	}
}
