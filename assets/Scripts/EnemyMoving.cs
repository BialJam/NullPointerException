using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {
	public float range;
	public float speed;
	private Rigidbody2D enemyBody;
	private Vector2 startPosition;
	private Vector2 currentPosition;
	private bool isLeft;

	void Start () {
		enemyBody = gameObject.GetComponent<Rigidbody2D>();
		startPosition = enemyBody.position;
	}

	void Update () {

		currentPosition = enemyBody.position;

		if (isLeft) {
			if (currentPosition.x < startPosition.x + range)
				enemyBody.AddForce (-Vector2.left * speed);
			else isLeft = false;
		} else {
			if (currentPosition.x > startPosition.x - range)
				enemyBody.AddForce(Vector2.left*speed);
			else isLeft = true;
			}


			}
}