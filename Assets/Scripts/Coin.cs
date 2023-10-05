using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action CoinCollected; //event that will invoke when player collides with player

    [SerializeField] private float rotationSpeed = 50f;

   
    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0); //rotating coin continously
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinCollected?.Invoke(); //Invoke if the event has any subscribers
            FindObjectOfType<AudioManager>().PlaySound("Coin");
            Destroy(gameObject);
        }
    }
    
}
