using UnityEngine;
using System.Collections;

public class DialogPrinter : MonoBehaviour {

	public string message;
	private TextMesh textMesh;
	// Use this for initialization
	void Start () {
		textMesh = this.GetComponentInChildren<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.name == "hero")
			textMesh.text = message;
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.name == "hero")
			textMesh.text = "";
}
}
