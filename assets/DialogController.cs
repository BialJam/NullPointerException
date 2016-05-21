using UnityEngine;
using System.Collections;

public class DialogController : MonoBehaviour {

	public string[] dialogs;
	public string text;

	private TextMesh npcTextMesh;
	private TextMesh playerTextMesh;
	private MeshRenderer npcRenderer;
	private MeshRenderer playerRenderer;
	private int index = 0;
	int size;
	void Start () {
		npcTextMesh = this.GetComponentInChildren<TextMesh> ();
		playerTextMesh = GameObject.Find("hero").GetComponentInChildren<TextMesh> ();
		npcRenderer = this.GetComponentInChildren<MeshRenderer> ();
		playerRenderer = GameObject.Find ("hero").GetComponentInChildren<MeshRenderer> ();
		size = dialogs.Length;
		StartCoroutine ("DialogSwitch");
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
