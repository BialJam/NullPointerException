using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DevidedQuestions : MonoBehaviour {

	int firstNumber;
	int secondNumber;
	int answer=0;
	int userAnswer=0;
	bool answerState = false;

	private Text firstNumberText;
	private Text secondNumberText;
	private InputField inputField;

	// Use this for initialization
	void Start () {

		firstNumberText = GameObject.Find ("FirstNumber").GetComponent<Text>();
		secondNumberText = GameObject.Find ("SecondNumber").GetComponent<Text>();
		inputField = GameObject.Find ("InputField").GetComponent<InputField> ();

		int fn = Random.Range (1, 40);
		int sn = Random.Range(1,20);
		firstNumber = fn * sn;
		secondNumber = fn;
		answer = sn;

		firstNumberText.text = System.Convert.ToString (firstNumber);
		secondNumberText.text = System.Convert.ToString (secondNumber);

	}

	public void checkAnswer() {
		userAnswer = System.Convert.ToInt32(inputField.text);

		if (userAnswer == answer)
			SceneManager.LoadScene (PlayerStats.actualScene + 1);
		else {
			PlayerStats.lifes--;
			SceneManager.LoadScene (PlayerStats.actualScene + 1);
		}
	}
		
}
