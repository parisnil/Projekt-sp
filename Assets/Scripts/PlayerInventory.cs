using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
