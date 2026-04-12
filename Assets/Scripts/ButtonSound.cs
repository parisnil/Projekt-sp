using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public void PlayClick()
    {
        Debug.Log("CLICK TRIGGERED");

        if (UISoundManager.instance == null)
        {
            Debug.LogError("UISoundManager MISSING!");
            return;
        }

        UISoundManager.instance.PlayClick();
    }
}


