using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.1f;    
    }

    public void Restart()
    {
        Debug.Log("EWS");
        GameManager.instance.Respawn();
    }

    public void Menu()
    {
        GameManager.instance.BackToMenu();
    }
}
