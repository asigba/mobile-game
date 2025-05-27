using System.Net.NetworkInformation;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Make sure the music loops
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().volume = 0.2f;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}