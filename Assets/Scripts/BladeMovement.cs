using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BladeMovement : MonoBehaviour
{
    //public AudioSource saw;
    //public bool isSpinning = false;
     [SerializeField] Vector3 movementVector = new Vector3();
    float movementFactor;
    [SerializeField] float period = 1f; //time for 1 cycle(4sec)
    Vector3 startingpos;

    void Start()
    {
        startingpos = transform.position;

    }


    void Update()
    {
        if (period <= 0f) return;

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSineWave / 2f + 0.5f);

       


        Vector3 offset = movementVector * movementFactor;
        transform.position = startingpos + offset;

    }
}