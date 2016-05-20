using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointUpdate : MonoBehaviour {

	void Start () {
        GetComponent<Text>().text += "0";

    }
	
	public void UpdatePoints() {
		GetComponent<Text>().text += PlayerStats.Points.ToString();
	}

}
