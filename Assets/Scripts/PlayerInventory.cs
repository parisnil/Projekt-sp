using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public List<BagItem> items = new();
    public BagUI bagUI;

    public void AddItem(BagItem item)
    {
        items.Add(item);
        bagUI.AddIcon(item.icon);
    }
}