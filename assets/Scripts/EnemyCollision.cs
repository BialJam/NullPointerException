using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

	void Start () {
	
	}
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D player) {
		if (player.name == "hero") {
			PlayerStats.Lifes --;
			SceneManager.LoadScene(PlayerStats.ActualScene);
		}
	}

}
