using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour {

	private string text;
	private TextMesh textMesh;
	void Start () {
		textMesh = gameObject.GetComponentInChildren<TextMesh> ();
		text = textMesh.text;
		textMesh.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return)) {
			SceneManager.LoadScene(PlayerStats.ActualScene);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.name == "hero") {
			textMesh.text = text;
		}

	}
}
