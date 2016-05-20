using UnityEngine;
using System.Collections;

public class FallDown : MonoBehaviour {
	
	private GameObject playerObject;
	private Camera cam;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.Find ("hero");
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		float position = 0 - (cam.orthographicSize);

		if (playerObject.transform.position.y < position) {
			PlayerStats.lifes--;
			//SceneManager.LoadScene(PlayerStats.ActualScene);
			Debug.Log("DEAD");
	}
}
}