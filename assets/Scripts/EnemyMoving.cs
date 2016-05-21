using UnityEngine;
using System.Collections;

public class EnemyMoving : MonoBehaviour
{
	public float range;
	public float speed;
	public float seeRange;
	private GameObject playerObject;
	private Rigidbody2D playerBody;
	private Rigidbody2D enemyBody;
	private Vector2 startPosition;
	private Vector2 currentPosition;
	private bool isLeft;
	private Vector2 playerPosition;
	private bool isPlayerInRange;

	void Start ()
	{
		enemyBody = gameObject.GetComponent<Rigidbody2D> ();
		startPosition = enemyBody.position;
		isPlayerInRange = false;
		isLeft = false;
		playerObject = GameObject.Find ("hero");
		playerBody = playerObject.GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		playerPosition = playerBody.position;
		currentPosition = enemyBody.position;

		if (!isPlayerInRange) {
			if (isLeft) {
				if (currentPosition.x < startPosition.x + range)
					enemyBody.velocity = new Vector2(-Vector2.left.x * speed, enemyBody.velocity.y);
				else
					isLeft = false;
			} else {
				if (currentPosition.x > startPosition.x - range)
					enemyBody.velocity = new Vector2(Vector2.left.x * speed, enemyBody.velocity.y);
				else
					isLeft = true;
			}
		} 

		if (playerPosition.x >= currentPosition.x - seeRange && playerPosition.x <= currentPosition.x + seeRange) {
			if (playerPosition.x - currentPosition.x < 0) {
				isPlayerInRange = true;
				enemyBody.velocity = new Vector2(Vector2.left.x * speed, enemyBody.velocity.y);
			} else if (playerPosition.x - currentPosition.x > 0) {
				enemyBody.velocity = new Vector2(-Vector2.left.x * speed, enemyBody.velocity.y);
				isPlayerInRange = true;
			} 
		} else { 
			isPlayerInRange = false;
	}
}
}