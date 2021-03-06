﻿using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeX;
	public float smoothTimeY;

	GameObject player;

	void Start () {
		player = GameObject.Find("hero");
	}
	

	void FixedUpdate () {

		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		//float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3(posX, transform.position.y, transform.position.z);
	
	}

}
