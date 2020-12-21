using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform respawnPoint;
    public int maxPoints = 0;
    public int points = 0;
    private void Awake()
    {
        instance = this;
        points = 0;
    }



    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Complete()
    {
        SceneManager.LoadScene(0);
    }
}
