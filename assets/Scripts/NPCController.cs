using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

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

	void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.name == "hero") {
			spriteRenderer.sprite = secondSprite;
			if (isFlipped)
				spriteRenderer.flipX = false;

			if (playerBody.transform.position.x > npcBody.transform.position.x) {
				if (!isFlipped)
					spriteRenderer.flipX = true;
			} else {
					spriteRenderer.flipX = false;
			}
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
		while (size >= 0) {
			Vector3 scale = playerRenderer.transform.localScale;
			scale.x = 0.02f;
			playerRenderer.transform.localScale = scale;
			if (!checkIndex()) {
				break;
			}
			npcTextMesh.text = dialogs[index];
			yield return new WaitForSeconds (2);
			npcRenderer.enabled = false;
			playerRenderer.enabled = true;
			index++;
			if (!checkIndex()) {
				break;
			}
			playerTextMesh.text = dialogs[index];
			yield return new WaitForSeconds (2);
			npcRenderer.enabled = true;
			playerRenderer.enabled = false;
			index++;
			size-=2;
		}
	}

}

