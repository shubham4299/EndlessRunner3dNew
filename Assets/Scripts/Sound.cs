using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public float volume;
    public AudioClip clip;
    public bool loop;
    public AudioSource source;
}
