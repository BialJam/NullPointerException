using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextPrinter : MonoBehaviour {

	public string[] parts;
	private Text text;

	void Start () {
		text = GameObject.Find ("Text").GetComponent<Text> ();
		StartCoroutine ("printText");
	}

	void Update () {
		if (Input.GetKey (KeyCode.KeypadEnter) || Input.GetKey (KeyCode.Return)) {
			SceneManager.LoadScene (0);
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
