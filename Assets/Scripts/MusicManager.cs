using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioSource audioSource;

    void Awake()
    {
        instance = this;
    }

    public void StopMusic()
    {
        if (audioSource != null)
            audioSource.Stop();
    }
}
