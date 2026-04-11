using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public BagItem item;
    public int price;

    public Button buyButton;
    public TMP_Text buttonText;

    bool bought = false;

    void Start()
    {
        buttonText.text = price + " XP";
    }

    public void Buy()
    {
        if (bought) return;

        int xp = PlayerPrefs.GetInt("RunXP", 0);

        if (xp < price)
        {
            buttonText.text = "NOT ENOUGH EXP";
            return;
        }

        xp -= price;
        PlayerPrefs.SetInt("RunXP", xp);

        PlayerInventory.pendingItems.Add(item);

        bought = true;
        buttonText.text = "BOUGHT";
        buyButton.interactable = false;
    }
}
