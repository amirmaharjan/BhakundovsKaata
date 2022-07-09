using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {

	public float jumpForce = 5f;
	public float rightForce = 2f;
	public float leftForce = 2f;
	public Rigidbody2D rb;
	public bool isDead = false;
	float timer;
	public bool timercondition;
	public Sprite WhiteBall;
	public Sprite SmallWhiteBall;
	public Sprite BlackBall;
	public Sprite SmallBlackBall;
	public Sprite RedBall;
	public Sprite SmallRedBall;
	public Sprite OrangeBall;
	public Sprite SmallOrangeBall;
	public CircleCollider2D ball;
	public static BallMovement instance;
	public bool alreadyPlayed = false;
	public bool alreadyPlayed2 = false;

	void Awake(){
		timer = 750 * Time.deltaTime;
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = WhiteBall;
	}

	void Start () {
		timercondition = false;
		rb = GetComponent<Rigidbody2D> ();
		rb.gravityScale = 0f;
		if (OptionController.Isblack == true) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = BlackBall;
		} else if (OptionController.Isred == true) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = RedBall;
		} else if (OptionController.Isorange == true) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = OrangeBall;
		} else if (OptionController.Isorange == true) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = WhiteBall;
		}
		ball = ball.GetComponent<CircleCollider2D> ();
		//ball.radius = 0.2229136f;
		ball.radius = 0.2272039f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0 && isDead == false) {
		  	rb.gravityScale = 1.5f;
			TouchMove ();
		}

		if(timercondition ==  true){
			//Debug.Log ("timer is ghating");
			timer--;
		}

		if(timer < 0){
			//Debug.Log ("Pause Function calling");
				pause ();
		}


//		if (isDead == false) {
//			if (Input.GetButtonDown ("JumpUp")) {
//				rb.velocity = Vector2.up * jumpForce;
//				FindObjectOfType<AudioManager> ().Play ("Touch");
//			} else if (Input.GetMouseButtonDown (1)) {
//				rb.velocity = Vector2.right * rightForce;
//			} else if (Input.GetMouseButtonDown (0)) {
//				rb.velocity = Vector2.left * leftForce;
//			}
//		}
			


		if(this.gameObject.transform.position.y < -8){
			if (!alreadyPlayed) {
				FindObjectOfType<AudioManager> ().Play ("GameOver");
				alreadyPlayed = true;
			}
			Destroy (this.transform.gameObject);
			isDead = true;
			GameController.instance.gameOver = true;
			pause();
		}

		if(this.gameObject.transform.position.y > 6.06){
			if (!alreadyPlayed) {
				FindObjectOfType<AudioManager> ().Play ("GameOver");
				alreadyPlayed = true;
			}
			Destroy (this.transform.gameObject);
			isDead = true;
			GameController.instance.gameOver = true;
			pause();
		}

		if(this.gameObject.transform.position.x < -3.73){
			if (!alreadyPlayed) {
				FindObjectOfType<AudioManager> ().Play ("GameOver");
				alreadyPlayed = true;
			}
			Destroy (this.transform.gameObject);
			isDead = true;
			GameController.instance.gameOver = true;
			pause();
		}

		if(this.gameObject.transform.position.x > 3.76){
			if (!alreadyPlayed) {
				FindObjectOfType<AudioManager> ().Play ("GameOver");
				alreadyPlayed = true;
			}
			Destroy (this.transform.gameObject);
			isDead = true;
			GameController.instance.gameOver = true;
			pause();
		}



	}

	public void TouchMove(){

		if (Input.touchCount > 0) {
		
			Touch touch = Input.GetTouch (0);
			float area = Screen.width / 3;

			if (touch.position.x < area && touch.phase == TouchPhase.Began) {
				rb.velocity = Vector2.left * leftForce;
			}
			if (touch.position.x >= area && touch.position.x < 2 * area && touch.phase == TouchPhase.Began) {
				FindObjectOfType<AudioManager> ().Play ("Touch");
				rb.velocity = Vector2.up * jumpForce;
			}
			if (touch.position.x >= 2 * area && touch.phase == TouchPhase.Began) {
				rb.velocity = Vector2.right * rightForce;
			}
		
		}

	}

	void OnCollisionEnter2D (Collision2D coll) {
		//GameController.instance.GameOver ();
		if (coll.gameObject.tag == "Obstacle") {
			if (!alreadyPlayed) {
				FindObjectOfType<AudioManager> ().Play ("GameOver");
				alreadyPlayed = true;
			}
			isDead = true;
			GameController.instance.gameOver = true;
			rb.bodyType = RigidbodyType2D.Static;
			Debug.Log ("Done");
			timercondition = true;
		}

	}

	IEnumerator makeSmall(float smallTime){
		Debug.Log ("Started");
			if (this.GetComponent<SpriteRenderer> ().sprite == WhiteBall) {
				this.GetComponent<SpriteRenderer> ().sprite = SmallWhiteBall;
			} else if (this.GetComponent<SpriteRenderer> ().sprite == BlackBall) {
				this.GetComponent<SpriteRenderer> ().sprite = SmallBlackBall;
			} else if (this.GetComponent<SpriteRenderer> ().sprite == RedBall) {
				this.GetComponent<SpriteRenderer> ().sprite = SmallRedBall;
			} else if (this.GetComponent<SpriteRenderer> ().sprite == OrangeBall) {
				this.GetComponent<SpriteRenderer> ().sprite = SmallOrangeBall;
			}
			//ball.radius = 0.1617297f;
			ball.radius = 0.1645803f;
			yield return new WaitForSeconds (smallTime);
			if (this.GetComponent<SpriteRenderer> ().sprite == SmallWhiteBall) {
				this.GetComponent<SpriteRenderer> ().sprite = WhiteBall;
			} else if (this.GetComponent<SpriteRenderer> ().sprite == SmallBlackBall) {
				this.GetComponent<SpriteRenderer> ().sprite = BlackBall;
			} else if (this.GetComponent<SpriteRenderer> ().sprite == SmallRedBall) {
				this.GetComponent<SpriteRenderer> ().sprite = RedBall;
			} else if (this.GetComponent<SpriteRenderer> ().sprite == SmallOrangeBall) {
				this.GetComponent<SpriteRenderer> ().sprite = OrangeBall;
			}
			ball.radius = 0.2272039f;
			//ball.radius = 0.2229136f;
	}

	private void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Star") {
			//anim.SetTrigger ("Power");
			//this.GetComponent<SpriteRenderer>().sprite = SmallWhiteBall;
			//ball.radius = 0.1715064f;
			//spriteR.sprite = SmallWhiteBall;
			FindObjectOfType<AudioManager>().Play("Star");
			StartCoroutine (makeSmall(4));
			GameController.instance.Crossed ();
			GameObject destroyCollidedStar = Star.instance.starCollection.Find (coll.gameObject).Value.gameObject;
			Destroy (destroyCollidedStar);
			Star.instance.starCollection.Remove (Star.instance.starCollection.Find (coll.gameObject));
		}
	}
		
	public void pause(){
		GameController.instance.gameOver = false;
		GameController.instance.regame = true;
		//Debug.Log ("Pause Called");
		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.gravityScale = 1.5f;
		if (!alreadyPlayed2) {
			GameController.instance.GameOver ();
			alreadyPlayed2 = true;
		}
	}

	public void Back(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		SceneManager.LoadScene ("Menu");
	}

}
