using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class SpriteCounter : MonoBehaviour
{
    public Image icon;          
    public TMP_Text text;       
    public int maxCount = 20;

    private int currentCount = 0;

    private void Start()
    {
        UpdateText();
    }

    public void AddCount()
    {
        currentCount++;
        if (currentCount > maxCount) currentCount = maxCount;
        UpdateText();
    }

    public void ResetCount(int newMax)
    {
        currentCount = 0;
        maxCount = newMax;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = currentCount + "/" + maxCount;
    }
}
