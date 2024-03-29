using System.Net.Mime;
using System.Linq.Expressions;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
     
public class PauseMenu : MonoBehaviour
{
     
    public static bool GameIsPaused = false;
         
    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
     
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    public void LoadMenu()
    {
        Debug.Log("MainMenu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MENU");
    }
     
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}