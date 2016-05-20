using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float moveSpeedX = 5;
	public float moveSpeedY = 10;
	private Rigidbody2D playerBody;
	public int speed;
	public bool isJumping=false;
	void Start () {
		playerBody = gameObject.GetComponent<Rigidbody2D>();
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "canJump") {
			isJumping = false;
		} 
	}

	void Update () {
		if (Input.GetKey (KeyCode.A))
			playerBody.AddForce (Vector2.left * moveSpeedX);
		else if (Input.GetKey (KeyCode.D))
			playerBody.AddForce (-Vector2.left * moveSpeedX);
		else if (Input.GetKey (KeyCode.W)) {
			if (isJumping==false) {
				playerBody.AddForce (Vector2.up * moveSpeedY);
				isJumping = true;
			}
		}
		else if (Input.GetKey (KeyCode.S))
			playerBody.AddForce (-Vector2.up * moveSpeedY);






	}

	}

