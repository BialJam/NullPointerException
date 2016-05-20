using UnityEngine;
using System.Collections;

public class DevidedQuestions : MonoBehaviour {

	int firstNumber;
	int secondNumber;
	int answer=0;
	string stringToEdit="1";
	bool answerState = false;

	// Use this for initialization
	void Start () {
		int fn = Random.Range (1, 100);
		int sn = Random.Range(1,100);
		firstNumber = fn * sn;
		secondNumber = fn;
		answer = sn;

	}
	
	// Update is called once per frame
	void Update () {
		if (stringToEdit == System.Convert.ToString(answer))
			answerState = true;
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), System.Convert.ToString(firstNumber)+" / "
			+System.Convert.ToString(secondNumber));
		stringToEdit = GUI.TextField(new Rect(110, 10, 50, 20), stringToEdit, 10);
		if (answerState == true) {
			GUI.Label(new Rect(100,100,200,20),"CORRECT ANSWER MAN!!!!!!!!!!");
		}

	}
}
