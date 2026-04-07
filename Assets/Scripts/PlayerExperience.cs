using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int currentExp = 0;

    void Start()
    {
        LoadExp();
    }

    public void AddExp(int amount)
    {
        currentExp += amount;
        Debug.Log("EXP: " + currentExp);
    }

    public void SaveExp()
    {
        PlayerPrefs.SetInt("RunXP", currentExp);
    }

    public void LoadExp()
    {
        currentExp = PlayerPrefs.GetInt("RunXP", 0);
    }
}
