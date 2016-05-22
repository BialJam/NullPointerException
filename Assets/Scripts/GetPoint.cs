using UnityEngine;
using System.Collections;

public class GetPoint : MonoBehaviour {

    public AudioClip clip;

	void Start () {
	
	}
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D hero)
    {
        if (hero.name == "hero" || hero.name == "CircleCollider")
        {
            PlayerStats.Points++;
            
            Destroy(gameObject);
			AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }
}
