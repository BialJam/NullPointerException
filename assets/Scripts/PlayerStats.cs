using UnityEngine;
using System.Collections;

public class PlayerStats {

    public static int lifes = 5;
    public static string actualScene = "mainScene";
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
            GameObject.Find("Points").GetComponent<PointUpdate>().UpdatePoints();
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
    public static int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
            GameObject.Find("Lifes").GetComponent<LifesUpdate>().UpdateLifes();
        }
    }

}
