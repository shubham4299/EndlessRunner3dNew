using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    bool isPaused;
    [SerializeField] private GameObject pauseMenuPanel;
    private void Update()
    {
        if (PlayerManager.gameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                FindObjectOfType<AudioManager>().PlaySound("Pause");
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        
    }
    public void ReloadGame()
    {
        Time.timeScale = 1.0f;
        PlayerManager.gameOver = false;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

}
