using UnityEngine;
using TMPro;

public class XPDisplay : MonoBehaviour
{
    public TMP_Text xpText;

    void Start()
    {
        int xp = PlayerPrefs.GetInt("RunXP", 0);
        xpText.text = "EXP: " + xp;
    }
}

