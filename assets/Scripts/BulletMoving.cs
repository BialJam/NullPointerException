using UnityEngine;
using System.Collections;

public class BulletMoving : MonoBehaviour {

    private bool direction;
    public float speed;
    private Camera cam;
    
	void Start () {
        cam = Camera.main;
        direction = playerMovement.dirToRight;
	}
	
	void Update () {
        if (direction == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            Debug.Log("niby strzelam w prawo ale jestem głupim oszustem");
        } 
        else
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        float position1 = 0 - (cam.orthographicSize * Screen.width / Screen.height);
        float position2 = 0 + (cam.orthographicSize * Screen.width / Screen.height);
        if (gameObject.transform.position.x < position1 || gameObject.transform.position.x > position2)
            Destroy(gameObject);
        Debug.Log(direction);
    }

    void OnTriggerEnter2D (Collider2D element)
    {
        if (element.name != "hero")
            Destroy(gameObject);
    }
}
