using UnityEngine;

public class Voicelines : MonoBehaviour
{
    public AudioClip[] voicelines;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public System.Collections.IEnumerator PlayVoiceline()
    {
        if (voicelines != null && voicelines.Length > 0)
        {
            int idx = Random.Range(1, voicelines.Length);
            // Popping sound
            audioSource.PlayOneShot(voicelines[0]);
            if (voicelines.Length > 1)
            {
                if (voicelines.Length == 3)
                {
                    // Color of shape
                    audioSource.PlayOneShot(voicelines[1]);
                    yield return new WaitForSeconds(0.5f);

                    // Shape
                    audioSource.PlayOneShot(voicelines[2]);
                }
                else
                {
                    //Random compliments
                    yield return new WaitForSeconds(1f);
                    audioSource.PlayOneShot(voicelines[idx]);
                }
            }
        }
    }
}