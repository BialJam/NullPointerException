using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LetsGoButton : MonoBehaviour {

	public void goToMainScene() {
		SceneManager.LoadScene(2);
	}
}
