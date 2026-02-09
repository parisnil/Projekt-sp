using TMPro;
using UnityEngine;

public class ExpUI : MonoBehaviour
{
    public PlayerExperience playerExp;
    private TMP_Text expText;

    void Awake()
    {
        expText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (playerExp != null)
        {
            expText.text = "EXP: " + playerExp.currentExp;
        }
    }
}
