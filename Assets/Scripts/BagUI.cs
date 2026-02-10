using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    public Transform slotParent;
    public GameObject iconPrefab;

    public void AddIcon(Sprite sprite)
    {
        GameObject icon = Instantiate(iconPrefab, slotParent);
        icon.GetComponent<Image>().sprite = sprite;
    }
}
