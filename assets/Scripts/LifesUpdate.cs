using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifesUpdate : MonoBehaviour {

    void Start()
    {

        UpdateLifes();
    }

    public void UpdateLifes()
    {

        GetComponent<Text>().text = "Lifes:" + PlayerStats.Lifes.ToString();
    }
}
