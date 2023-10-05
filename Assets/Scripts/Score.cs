using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinText;
    private float score = 0f;
    private Vector3 lastPosition;

    void Start()
    {
        // Store the initial position of the player
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate the distance the player has moved along the z-axis
        float distance = transform.position.z;

        // Add this distance to the score
        score = Mathf.Round(distance) + GetComponent<PlayerController>().coins;
        scoreText.text = "Distance: " + score;
        coinText.text ="Coins: " + GetComponent<PlayerController>().coins;


        // Store the current position for the next frame
        //lastPosition = transform.position;

        // Display the score
        Debug.Log("Score: " + score);
    }
}

