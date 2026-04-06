using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    public Transform slotParent;
    public GameObject iconPrefab;

    public void AddIcon(BagItem item)
    {
        GameObject icon = Instantiate(iconPrefab, slotParent);

        Image img = icon.GetComponent<Image>();
        img.sprite = item.icon;

        Button btn = icon.GetComponent<Button>();

        btn.onClick.AddListener(() =>
        {
            UseItem(item);
            Destroy(icon);
        });
    }

    void UseItem(BagItem item)
    {
        if (item.type == BagItemType.Weapon)
        {
            WeaponManager wm = FindFirstObjectByType<WeaponManager>();

            if (wm != null && item.weaponPrefab != null)
            {
                wm.EquipWeapon(item.weaponPrefab);
            }
        }
        else if (item.type == BagItemType.Bomb)
        {
            PlayerBomb bomb = FindFirstObjectByType<PlayerBomb>();

            if (bomb != null)
                bomb.Explode();
        }
        else if (item.type == BagItemType.Speed)
        {
            PlayerSpeed speed = FindFirstObjectByType<PlayerSpeed>();

            if (speed != null)
                speed.ActivateSpeedBoost();
        }
    }
}

