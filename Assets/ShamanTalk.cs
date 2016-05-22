using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShamanTalk : MonoBehaviour {

	public Sprite secondSprite;
	public string[] dialogs;

	private TextMesh textMesh;
	private Rigidbody2D playerBody;
	private Rigidbody2D npcBody;
	private SpriteRenderer spriteRenderer;
	private Sprite originalSprite;
	private bool isFlipped;
	private TextMesh npcTextMesh;
	private TextMesh playerTextMesh;
	private MeshRenderer npcRenderer;
	private MeshRenderer playerRenderer;
	private int index = 0;
	private int size = 0;
	// Use this for initialization
	void Start () {
		isFlipped = false;
		textMesh = this.GetComponentInChildren<TextMesh> ();
		playerBody = GameObject.Find ("hero").GetComponent<Rigidbody2D> ();
		npcBody = this.GetComponent<Rigidbody2D> ();
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
		originalSprite = spriteRenderer.sprite;
		npcTextMesh = this.GetComponentInChildren<TextMesh> ();
		playerTextMesh = GameObject.Find("hero").GetComponentInChildren<TextMesh> ();
		npcRenderer = this.GetComponentInChildren<MeshRenderer> ();
		playerRenderer = GameObject.Find ("hero").GetComponentInChildren<MeshRenderer> ();
		size = dialogs.Length;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.name == "hero") {
			StartCoroutine ("DialogSwitch");

			spriteRenderer.sprite = secondSprite;
			if (isFlipped)
				spriteRenderer.flipX = false;

			if (playerBody.transform.position.x > npcBody.transform.position.x) {
				if (!isFlipped)
					spriteRenderer.flipX = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.name == "hero") {
			StopCoroutine ("DialogSwitch");
			index = 0;
			size = dialogs.Length;
			textMesh.text = "";
			playerTextMesh.text = "";
			npcRenderer.enabled = true;
			playerRenderer.enabled = false;
			isFlipped = false;
			spriteRenderer.flipX = false;
			spriteRenderer.sprite = originalSprite;
		}
	}

	private bool checkIndex() {
		if (index >= dialogs.Length) {
			npcTextMesh.text = "";
			playerTextMesh.text = "";
			return false;
		}
		return true;
	}

	IEnumerator DialogSwitch() {
		bool p1 = false;
		bool p2 = false;
		Vector3 scale = playerRenderer.transform.localScale;
		scale.x = 0.02f;
		playerRenderer.transform.localScale = scale;
		// 1
		npcRenderer.enabled = true;
		playerRenderer.enabled = false;
		npcTextMesh.text = "Witaj mlody czlowieku.\nWygladasz na dzielnego woja o czystym sercu!";
		while (!Input.GetKey (KeyCode.Space) ) {
			yield return null;
		}
		yield return new WaitForSeconds (0.2f);
		//2
		npcRenderer.enabled = false;
		playerRenderer.enabled = true;
		playerTextMesh.text = "Eeeee....co?";
		while (!Input.GetKey (KeyCode.Space)) {
			yield return null;

		}
		yield return new WaitForSeconds (0.2f);
		//3
		npcRenderer.enabled = true;
		playerRenderer.enabled = false;
		npcTextMesh.text = "Pozwol, ze opowiem Ci legende...";
		while (!Input.GetKey (KeyCode.Space)) {
			yield return null;
		}
		yield return new WaitForSeconds (0.2f);
		//4
		npcRenderer.enabled = false;
		playerRenderer.enabled = true;
		playerTextMesh.text = "K.";
		while (!Input.GetKey (KeyCode.Space)) {
			yield return null;
		}
		yield return new WaitForSeconds (0.2f);


		while (!Input.GetKey (KeyCode.Space)) {
			yield return null;
		}
		yield return new WaitForSeconds (0.2f);

		SceneManager.LoadScene (3);



	}

}