using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI distanceText;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI HighScoreText;
    [SerializeField] TextMeshProUGUI coinText;
    private float score = 0f;
    private Vector3 lastPosition;


    void Start()
    {
        //totalCoins = 0f;
        // Store the initial position of the player
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate the distance the player has moved along the z-axis
        float distance = transform.position.z;

        ScoreText.text = score.ToString();
        HighScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();

        // Add this distance to the score
        score = Mathf.Round(distance) + GetComponent<PlayerController>().coins;
        distanceText.text = "Distance: " + score;
        coinText.text ="Coins: " + GetComponent<PlayerController>().coins;

        //totalCoins += GetComponent<PlayerController>().coins;

       // PlayerPrefs.SetFloat("totalCoins", GetComponent<PlayerController>().coins);

        if (score > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
        // Store the current position for the next frame
        //lastPosition = transform.position;

        // Display the score
        //Debug.Log("Score: " + score);
    }
}

