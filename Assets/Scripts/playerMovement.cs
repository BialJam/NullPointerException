using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float moveSpeedY;
	private Rigidbody2D playerBody;
	public bool isJumping=false;
    private bool dirToRight=true;
    Animator anim;
    public float speed;

	void Start () {
		playerBody = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "canJump") {
			isJumping = false;
		} 
	}

	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        playerBody.velocity = new Vector2(moveHorizontal * speed, playerBody.velocity.y);
        if (moveHorizontal < 0 && dirToRight)
            Flip();
        if (moveHorizontal > 0 && !dirToRight)
            Flip();
        anim.SetFloat("speed", Mathf.Abs(moveHorizontal));
        if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			if (isJumping==false) {
				playerBody.AddForce (Vector2.up * moveSpeedY);
				isJumping = true;
			}
		}
        if (Input.GetKey(KeyCode.Space))
        {
            shoot();
        }
	}

    void Flip()
    {
        dirToRight = !dirToRight;
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }

    void shoot ()
    {

    }

	}

