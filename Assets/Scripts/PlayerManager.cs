using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    public static bool gameOver;
    
    void Start()
    {
        gameOver = false;
        //Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

    }
}
