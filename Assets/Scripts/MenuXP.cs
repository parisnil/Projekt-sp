using TMPro;
using UnityEngine;

public class MenuXP : MonoBehaviour
{
    public TMP_Text xpText;

    void Start()
    {
        int xp = PlayerPrefs.GetInt("RunXP", 0);
        xpText.text = "EXP: " + xp;
    }
}
