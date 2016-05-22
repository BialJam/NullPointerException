using UnityEngine;
using System.Collections;


public class KillEnemy : MonoBehaviour {

	public GameObject enemy;
    public AudioClip clip;
    public bool water;
	public int offset;
	private GameObject thisObject;
	private GameObject dupEnemy1 = null;
	private GameObject dupEnemy2 = null;
    private Animator anim;
	public bool duplicated = false;
	int i = 0;
	// Use this for initialization
	void Start () {
		//enemy = GameObject.FindWithTag ("enemy");
		//enemy = this.gameObject;
		thisObject = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setDuplicated()
	{
		duplicated = true;
	}
		
	void OnTriggerEnter2D (Collider2D coll) {
		
		if (coll.name == "groundTester" && GameObject.Find("hero").GetComponent<playerMovement>().getCanRun() && !water)
		if (duplicated == false) {
			float xPos = thisObject.transform.position.x;
			float yPos = thisObject.transform.position.y;

			string[] splitted = enemy.name.Split (' ');
			string nameToInstantiate = splitted [0];
			dupEnemy1 = Instantiate (Resources.Load (nameToInstantiate), new Vector3(xPos-offset,yPos,enemy.transform.position.z), Quaternion.identity) as GameObject;
			dupEnemy1.name = "dupEnemy" + System.Convert.ToString(i);
			dupEnemy1.GetComponent<KillEnemy> ().duplicated = true;
			dupEnemy2 = Instantiate (Resources.Load(nameToInstantiate),new Vector3(xPos+offset,yPos,enemy.transform.position.z),Quaternion.identity) as GameObject;
			dupEnemy2.GetComponent<KillEnemy> ().duplicated = true;
			Destroy (gameObject);
			duplicated = true;
		} else {
			
			Destroy (gameObject);
		}

        if (coll.gameObject.name == "hero")
        {
            if (coll.GetComponent<playerMovement>().getCanRun())
            {
                coll.gameObject.GetComponent<Animator>().SetTrigger("deathAnimation");
                AudioSource.PlayClipAtPoint(clip, transform.position);
                coll.GetComponent<playerMovement>().setCanRun(false);
            }
                
        }
	}
}
