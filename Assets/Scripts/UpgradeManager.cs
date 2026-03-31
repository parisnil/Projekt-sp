using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject upgradePanel;

    private bool choiceMade = false;

    public void UpgradeDamage()
    {
        if (choiceMade) return;

        choiceMade = true;

        PlayerStats.damageMultiplier *= 1.5f;
        CloseUI();
    }

    public void UpgradeSpeed()
    {
        if (choiceMade) return;

        choiceMade = true;

        PlayerStats.speedMultiplier *= 1.1f;
        CloseUI();
    }

    public void UpgradeHP()
    {
        if (choiceMade) return;

        choiceMade = true;

        PlayerLife player = FindFirstObjectByType<PlayerLife>();
        if (player != null)
            player.AddMaxHP(1);

        CloseUI();
    }

    void CloseUI()
    {
        if (upgradePanel != null)
            upgradePanel.SetActive(false);
    }

    public void ResetChoices()
    {
        choiceMade = false;
    }
}