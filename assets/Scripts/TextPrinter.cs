using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextPrinter : MonoBehaviour {

	public string[] parts;
	public int sceneToLoad;

	private Text text;
	void Start () {
		text = GameObject.Find ("Text").GetComponent<Text> ();
		StartCoroutine ("printText");
	}

	void Update () {
		if (Input.GetKey (KeyCode.KeypadEnter) || Input.GetKey (KeyCode.Return) || Input.GetKey(KeyCode.Space)) {
			SceneManager.LoadScene (sceneToLoad);
		}
	}

	IEnumerator printText() {
		string currentText = "";
		for (int i = 0; i < parts [0].Length; i++) {
			string textPart = parts [0];
			currentText = currentText + textPart [i];
			text.text = currentText;
			yield return new WaitForSeconds (0.035f);
		}

	}
}
