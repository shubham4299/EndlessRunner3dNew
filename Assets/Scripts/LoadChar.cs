using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadChar : MonoBehaviour
{
    public GameObject[] characterPrefabs;

    private void Start()
    {
        int selectedCharecter = PlayerPrefs.GetInt("selectedCharacter");
        //GameObject prefab = characterPrefabs[selectedCharecter];
        //GameObject clone= Instantiate(prefab,spawnPoint.position,Quaternion.identity);
        //label.text = prefab.name;
        characterPrefabs[selectedCharecter].SetActive(true);
        
    }
}
