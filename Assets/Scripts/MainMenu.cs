using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HighScore;
    [SerializeField] TextMeshProUGUI totalCoins;

    // Start is called before the first frame update
    void Start()
    {
        totalCoins.text =PlayerPrefs.GetFloat("totalCoins").ToString();
        HighScore.text = PlayerPrefs.GetFloat("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        HighScore.text = PlayerPrefs.GetFloat("HighScore").ToString();
        totalCoins.text = PlayerPrefs.GetFloat("totalCoins").ToString();
    }
}
