using UnityEngine;
using TMPro;

public class BossHPText : MonoBehaviour
{
    public BossAI boss;
    public TMP_Text text;

    void Start()
    {
        if (text == null)
            text = GetComponent<TMP_Text>();
    }

    void LateUpdate()
    {
        if (boss == null) return;

        text.text = "HP: " + boss.GetHP();
    }
}
