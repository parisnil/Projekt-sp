using UnityEngine;

public enum BagItemType
{
    Weapon,
    Bomb,
    Speed,
    Ammo,
    Health
}

public class BagItem : MonoBehaviour
{
    public BagItemType type;
    public Sprite icon; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerInventory inv = other.GetComponent<PlayerInventory>();
        if (inv != null)
        {
            inv.AddItem(this);
        }

        Destroy(gameObject);
    }
}