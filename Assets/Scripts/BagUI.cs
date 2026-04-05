using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    public Transform slotParent;
    public GameObject iconPrefab;

    public void AddIcon(Sprite sprite, GameObject weaponPrefab)
    {
        GameObject icon = Instantiate(iconPrefab, slotParent);

        Image img = icon.GetComponent<Image>();
        img.sprite = sprite;

        Button btn = icon.GetComponent<Button>();

        btn.onClick.AddListener(() =>
        {
            WeaponManager wm = FindFirstObjectByType<WeaponManager>();

            if (wm != null && weaponPrefab != null)
            {
                wm.EquipWeapon(weaponPrefab);
            }
            else
            {
                Debug.LogError("WeaponManager eller weaponPrefab är NULL");
            }
        });
    }
}
