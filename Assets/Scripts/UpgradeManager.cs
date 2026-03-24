using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public float damageMultiplier = 1f;
    public float speedMultiplier = 1f;
    public int hpBonus = 0;

    void Awake()
    {
        instance = this;
    }

    public void UpgradeDamage()
    {
        damageMultiplier *= 1.5f;
    }

    public void UpgradeSpeed()
    {
        speedMultiplier *= 1.1f;
    }

    public void UpgradeHP()
    {
        hpBonus += 1;
    }

    public void CloseUpgradeUI()
    {
        GameObject panel = GameObject.Find("UpgradePanel");
        if (panel != null)
            panel.SetActive(false);
    }
}
