using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KillEnemy : MonoBehaviour {

	public GameObject enemy;
	public int offset;
	private GameObject dupEnemy1 = null;
	private GameObject dupEnemy2 = null;
	public bool duplicated = false;
	// Use this for initialization
	void Start () {
		//enemy = GameObject.FindWithTag ("enemy");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setDuplicated()
	{
		duplicated = true;
	}


	void OnTriggerEnter2D (Collider2D coll) {
		
		if (coll.name == "killPoint")
		if (duplicated == false) {
			
			dupEnemy1 = Instantiate (Resources.Load (enemy.name), new Vector3(enemy.transform.position.x-offset,enemy.transform.position.y,enemy.transform.position.z), Quaternion.identity) as GameObject;
			dupEnemy1.GetComponent<KillEnemy> ().duplicated = true;
			dupEnemy2 = Instantiate (Resources.Load(enemy.name),new Vector3(enemy.transform.position.x+offset,enemy.transform.position.y,enemy.transform.position.z),Quaternion.identity) as GameObject;
			dupEnemy2.GetComponent<KillEnemy> ().duplicated = true;
			Destroy (gameObject);
			duplicated = true;
		} else {
			
			Destroy (gameObject);
		}
			
        if (coll.name == "hero")
        {
            PlayerStats.Lifes--;
            SceneManager.LoadScene(PlayerStats.ActualScene);
        }
    }
}
