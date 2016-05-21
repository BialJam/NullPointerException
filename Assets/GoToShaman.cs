using UnityEngine;
using System.Collections;

public class GoToShaman : MonoBehaviour {

	private GameObject player;
	private Rigidbody2D playerBody;  

	private GameObject Shaman;
	private Rigidbody2D shamanBody;
	private Animator anim;


	void Start () {
		player = GameObject.Find ("hero");
		playerBody = player.GetComponent<Rigidbody2D> ();
		Shaman = GameObject.Find ("Shaman");
		anim = player.GetComponent<Animator>();

	}
	

	void Update () {
		float moveHorizontal = 1f;
		if (player.transform.position.x < -2.5) 
		{
			playerBody.velocity = new Vector2 (moveHorizontal, playerBody.velocity.y);
			anim.SetFloat ("speed", 1);

		}
		else
		anim.SetFloat ("speed", 0);
		}
	}

