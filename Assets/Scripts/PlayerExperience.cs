using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int currentExp;

    void Start()
    {
        LoadExp();
    }

    public void AddExp(int amount)
    {
        currentExp += amount;
        SaveExp();
    }

    public void SpendExp(int amount)
    {
        currentExp -= amount;
        if (currentExp < 0) currentExp = 0;
        SaveExp();
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
