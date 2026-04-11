using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public List<BagItem> items = new();
    public static List<BagItem> pendingItems = new();

    public BagUI bagUI;

    void Start()
    {
        LoadRunItems();
    }

    void LoadRunItems()
    {
        items.Clear();

        foreach (BagItem item in pendingItems)
        {
            AddItem(item);
        }

        pendingItems.Clear();
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

        foreach (Transform child in bagUI.slotParent)
        {
            Destroy(child.gameObject);
        }
    }
}

