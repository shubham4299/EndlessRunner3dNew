using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour
{
    [SerializeField] ParticleSystem Explosion;

    public void explosion()
    {
        Explosion.Play();
    }
}
