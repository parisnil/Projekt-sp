using UnityEngine;
using UnityEngine.UI;

public class UIHearts : MonoBehaviour
{
    public static UIHearts instance;

    public Image[] hearts;

    void Awake()
    {
        instance = this;
    }

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHealth;
        }
    }
}
