using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class PlayerStats {

    public static int lifes = 5;
    public static string actualScene = "mainScene";
	public static int scene = 5; //cause it is first lvl
    public static int points = 0;


    public static int Lifes
    {
        get
        {
            return lifes;
        }

        set
        {
            lifes = value;
            GameObject.Find("life1").GetComponent<LifesUpdate>().UpdateLifes();
            GameObject.Find("life2").GetComponent<LifesUpdate>().UpdateLifes();
            GameObject.Find("life3").GetComponent<LifesUpdate>().UpdateLifes();
            GameObject.Find("life4").GetComponent<LifesUpdate>().UpdateLifes();
            GameObject.Find("life5").GetComponent<LifesUpdate>().UpdateLifes();
            if (lifes == 0)
            {
				SceneManager.LoadScene (0);
				lifes = 5;
				points = 0;
            }
            
        }
    } 
    public static string ActualScene
    {
        get
        {
            return actualScene;
        }
        set
        {
            actualScene = value;
        }
    }

	public static int Scene {

		get {
			return scene;
		}

		set {
			scene = value;
		}

	}

    public static int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
            GameObject.Find("Points").GetComponent<PointUpdate>().UpdatePoints();
        }
    }

}
