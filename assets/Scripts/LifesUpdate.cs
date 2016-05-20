using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifesUpdate : MonoBehaviour {

    void Start()
    {
        GetComponent<Text>().text += "5";

    }

    public void UpdateLifes()
    {
        GetComponent<Text>().text += PlayerStats.Lifes.ToString();
    }
}
