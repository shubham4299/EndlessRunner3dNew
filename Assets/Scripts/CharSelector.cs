using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelector : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter=0;

    public void NextCharacter()
    {
        Debug.Log("NextChar");
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1)% characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        Debug.Log("PrevChar");
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        Debug.Log("selected char: " + selectedCharacter);
        //SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
