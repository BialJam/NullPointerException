using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KillEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D element) {
		if (element.name == "killPoint" || element.tag == "bullet")
        {
            Destroy(gameObject);
        }
			

        if (element.name == "hero")
        {
            PlayerStats.Lifes--;
            SceneManager.LoadScene(PlayerStats.ActualScene);
        }
    }
}
