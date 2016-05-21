using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointUpdate : MonoBehaviour {

	void Start () {

        UpdatePoints();

    }
	
	public void UpdatePoints() {
		GetComponent<Text>().text = "Punkty:  " + PlayerStats.Points.ToString();
	}

}
