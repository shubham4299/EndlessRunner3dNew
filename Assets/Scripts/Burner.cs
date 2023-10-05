using UnityEngine;
using System.Collections;

public class Burner : MonoBehaviour
{
    [SerializeField] ParticleSystem[] FireParicle;
    private bool isPlaying = false;

    private void Start()
    {
        
        PlayAndStopParticleSystemAfterDelay(1f); // Play and stop the Particle System after 1 second
    }

    private void Update()
    {
        if (!isPlaying)
        {
            PlayAndStopParticleSystemAfterDelay(2f); // Play and stop the Particle System after 1 second

        }
    }
    private void PlayAndStopParticleSystemAfterDelay(float delay)
    {
        // Use a coroutine to play and stop the Particle System after a delay
        StartCoroutine(PlayAndStopAfterDelay(delay));
    }

    private IEnumerator PlayAndStopAfterDelay(float delay)
    {
        //yield return new WaitForSeconds(delay);
        // Start the Particle System
        for(int i=0; i<FireParicle.Length; i++)
        {
            FireParicle[i].Emit(1);

        }
        isPlaying = true;

        // Wait for 1 second
        yield return new WaitForSeconds(1.5f);
        isPlaying = false;
    }
}
