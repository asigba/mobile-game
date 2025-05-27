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
            audioSource.PlayOneShot(voicelines[0]);
            yield return new WaitForSeconds(1f);
            audioSource.PlayOneShot(voicelines[idx]);
        }
    }
}