using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadChange : MonoBehaviour
{
    [SerializeField] public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag == "Player")
        {
            playerPos.position= new Vector3(playerPos.position.x - 3,playerPos.position.y,playerPos.position.z);
            Debug.Log("Go left");
        }
    }
}
