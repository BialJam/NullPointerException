using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float moveSpeedY;
    public bool isJumping = false;
    private Rigidbody2D playerBody;
    public float speed;
    public Transform bullet;
    public float fireRate = 0.5F;

    public static bool dirToRight = true;   
    private float nextFire = 0.0F;
    private Animator anim;

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
        {
            dirToRight = !dirToRight;
            Flip();
        }
        if (moveHorizontal > 0 && !dirToRight)
        {
            dirToRight = !dirToRight;
            Flip();
        }
        if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			if (isJumping==false) {
				playerBody.AddForce (Vector2.up * moveSpeedY);
				isJumping = true;
			}
		}
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }
        anim.SetFloat("speed", Mathf.Abs(moveHorizontal));
    }

    void Flip()
    {
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
        
    }

    void shoot ()
    {
        Vector2 pos = gameObject.transform.position;
        Instantiate(bullet, pos, Quaternion.identity);
    }
}

