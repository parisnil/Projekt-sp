using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    [Header("Run items (bara i denna match)")]
    public List<BagItem> items = new();

    public BagUI bagUI;

    [Header("Owned items (från shop - koppla i Inspector)")]
    public BagItem gun1;
    public BagItem gun2;
    public BagItem bomb;
    public BagItem speed;

    void Start()
    {
        StartRun();
    }

    public void StartRun()
    {
        ResetRun();
        LoadOwnedItems();
    }

    void LoadOwnedItems()
    {
        if (PlayerPrefs.GetInt("gun1", 0) == 1)
            AddItem(gun1);

        if (PlayerPrefs.GetInt("gun2", 0) == 1)
            AddItem(gun2);

        if (PlayerPrefs.GetInt("bomb", 0) == 1)
            AddItem(bomb);

        if (PlayerPrefs.GetInt("speed", 0) == 1)
            AddItem(speed);
    }

    public void AddItem(BagItem item)
    {
        if (item == null) return;

        items.Add(item);
        bagUI.AddIcon(item);
    }

    public void ResetRun()
    {
        items.Clear();

        if (bagUI != null && bagUI.slotParent != null)
        {
            for (int i = bagUI.slotParent.childCount - 1; i >= 0; i--)
            {
                Destroy(bagUI.slotParent.GetChild(i).gameObject);
            }
        }
    }
}