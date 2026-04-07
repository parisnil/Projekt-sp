using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public string itemID;        
    public Button buyButton;
    public TMP_Text buttonText;

    private bool bought = false;

    public void Buy()
    {
        if (bought) return;

        PlayerPrefs.SetInt(itemID, 1);

        bought = true;
        buttonText.text = "OWNED";
        buyButton.interactable = false;
    }
}
