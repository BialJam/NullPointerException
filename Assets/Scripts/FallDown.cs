using UnityEngine;
using System.Collections;

public class FallDown : MonoBehaviour {
	
	private GameObject playerObject;
	private Camera cameraObj;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.Find ("hero");
	}
	
	// Update is called once per frame
	void Update () {
		float position = 0 - (Camera.current.orthographicSize);

		if (playerObject.transform.position.y < position) {
			PlayerStats.lifes--;
			SceneManager.LoadScene(PlayerStats.ActualScene);
	}
}

}
