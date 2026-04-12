using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    public static UISoundManager instance;

    public AudioSource audioSource;
    public AudioClip clickSound;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log("UISoundManager CREATED");
    }


    public void PlayClick()
    {
        if (audioSource != null && clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }
}
