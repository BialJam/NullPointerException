using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float moveSpeedY;
    public bool isJumping = false;
    private Rigidbody2D playerBody;
    public float speed;
    public Transform bullet;
    public float fireRate = 0.5F;
    public LayerMask layer;
    public Transform groundTester;

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
        /*if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W) && (Physics2D.OverlapCircle(groundTester.position, 0.1f, layer))) {
				playerBody.AddForce (Vector2.up * moveSpeedY);
				isJumping = true;
		} */
        jump();
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }
        anim.SetFloat("speed", Mathf.Abs(moveHorizontal));
    }

    void Flip()
    {
		SpriteRenderer renderer = this.GetComponent<SpriteRenderer> ();
		if (renderer.flipX == true) {
			renderer.flipX = false;
		} else
			renderer.flipX = true;
    }

    void shoot ()
    {
        Vector2 pos = gameObject.transform.position;
        Instantiate(bullet, pos, Quaternion.identity);
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && Physics2D.OverlapCircle(groundTester.position, 0.2f, layer))
        {
            playerBody.AddForce(new Vector2(0f, moveSpeedY));
        }
    }
}

