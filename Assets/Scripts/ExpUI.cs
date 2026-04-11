using TMPro;
using UnityEngine;

public class ExpUI : MonoBehaviour
{
    public PlayerExperience playerExp;
    private TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    void Start()
    {
        Refresh();
    }

    void Update()
    {
        Refresh();
    }

    void Refresh()
    {
        if (playerExp != null)
        {
            text.text = "EXP: " + playerExp.currentExp;
        }
    }
}
