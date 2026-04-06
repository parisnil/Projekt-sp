using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform gunHolder;

    GameObject currentWeapon;

    public void EquipWeapon(GameObject weaponPrefab)
    {
        Debug.Log("EquipWeapon CALLED: " + weaponPrefab);

        if (weaponPrefab == null)
        {
            Debug.LogError("weaponPrefab är NULL");
            return;
        }

        if (gunHolder == null)
        {
            Debug.LogError("gunHolder är NULL");
            return;
        }

        foreach (Transform child in gunHolder)
        {
            Destroy(child.gameObject);
        }

        currentWeapon = Instantiate(weaponPrefab, gunHolder);
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localRotation = Quaternion.identity;

        Debug.Log("Weapon spawned: " + currentWeapon.name);
    }
}
