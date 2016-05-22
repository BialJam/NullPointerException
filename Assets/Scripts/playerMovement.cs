using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

    public float moveSpeedY;
    public bool isJumping = false;
    private Rigidbody2D playerBody;
    public float speed;
    public Transform bullet;
    public float fireRate = 0.5F;
    public LayerMask layer;
    public Transform groundTester;
    public Transform startPoint;

    public static bool dirToRight = true;
    private float nextFire = 0.0F;
    private Animator anim;
    private bool canRun;


    void Start() {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        canRun = true;
    }
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "canJump") {
            isJumping = false;
        }
    }

    void Update() {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("heroDeath") || canRun == false)
        {
            playerBody.velocity = new Vector2(0, playerBody.velocity.y);
            anim.SetFloat("speed", 0);
            return;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        playerBody.velocity = new Vector2(moveHorizontal * speed, playerBody.velocity.y);
        if (moveHorizontal < 0 && dirToRight && canRun)
        {
            dirToRight = !dirToRight;
            Flip();
        }
        if (moveHorizontal > 0 && !dirToRight && canRun)
        {
            dirToRight = !dirToRight;
            Flip();
        }
        if (canRun)
        {
            jump();
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                shoot();
            }
        }
        anim.SetFloat("speed", Mathf.Abs(moveHorizontal));
    }

    void Flip()
    {
        SpriteRenderer renderer = this.GetComponent<SpriteRenderer>();
        if (renderer.flipX == true) {
            renderer.flipX = false;
        } else
            renderer.flipX = true;
    }

    void shoot()
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
    
    void restartHero()
    {
        Debug.Log("co sie tu dzieje sie");
        canRun = true;

        gameObject.transform.position = startPoint.position;
        PlayerStats.lifes -= 1;
    }
    public void setCanRun (bool var)
    {
        canRun = var;
    }
    public bool getCanRun()
    {
        return canRun;
    }

}

