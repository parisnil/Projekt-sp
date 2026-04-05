using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public GameObject weapon;

    public void OnClick()
    {
        if (weapon == null) return;

        WeaponManager wm = FindFirstObjectByType<WeaponManager>();
        wm.EquipWeapon(weapon);
    }
}
