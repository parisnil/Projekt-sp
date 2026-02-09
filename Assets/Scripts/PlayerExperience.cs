using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int currentExp = 0;

    public void AddExp(int amount)
    {
        currentExp += amount;
        Debug.Log("EXP: " + currentExp);
    }
}
