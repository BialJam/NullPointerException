using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float moveSpeedX = 5;
	public float moveSpeedY = 10;
	private Rigidbody2D playerBody;
	public int speed;
	public bool isJumping=false;
	// Use this for initialization
	void Start () {
		playerBody = gameObject.GetComponent<Rigidbody2D>();
		//canJump = transform.GetChild (0).gameObject.GetComponent<Collider2D> ();
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "canJump") {
			isJumping = false;
			Debug.Log ("jump true");
		} 
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (isJumping);
		if (Input.GetKey (KeyCode.A))
			playerBody.AddForce (Vector2.left * moveSpeedX);
		if (Input.GetKey (KeyCode.D))
			playerBody.AddForce (-Vector2.left * moveSpeedX);
		if (Input.GetKey (KeyCode.W)) {
			if (isJumping==false) {
				playerBody.AddForce (Vector2.up * moveSpeedY);
				isJumping = true;
			}
		}





	}

	}

