using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifesUpdate : MonoBehaviour {

    private int lifes;
    public int id;

    void Start()
    {
        initLifes();
        UpdateLifes();
    }

    public void UpdateLifes()
    {
        lifes = PlayerStats.lifes;
        if (id > lifes)
            gameObject.GetComponent<Image>().enabled = false;
    }

    public void initLifes()
    {
        gameObject.GetComponent<Image>().enabled = true;
    }
}
