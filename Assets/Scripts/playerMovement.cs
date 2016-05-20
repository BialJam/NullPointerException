using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    private float movex=0;
    private float movey=0;
    private float moveSpeed=5;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * moveSpeed, movey * moveSpeed);
	}
}
