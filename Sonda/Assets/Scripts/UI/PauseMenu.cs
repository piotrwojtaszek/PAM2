using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]GameObject pauseMenu = null;

    public void EnablePasueMenu()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void DisablePauseMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
