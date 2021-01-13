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
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Complete()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void CallDeadMenu()
    {
        GameObject deadMenu = Resources.Load<GameObject>("DeadMenu");
        Instantiate(deadMenu);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
