using UnityEngine;
using System.Collections;

public class GetPoint : MonoBehaviour {

	void Start () {
	
	}
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D hero)
    {
        if (hero.name == "hero")
        {
            PlayerStats.Points++;
            Destroy(gameObject);
        }
    }
}
