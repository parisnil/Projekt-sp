using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    public Transform slotParent;
    public GameObject iconPrefab;

    public void AddIcon(Sprite sprite)
    {
        GameObject icon = Instantiate(iconPrefab, slotParent);
        Image img = icon.GetComponent<Image>();
        img.sprite = sprite;

        RectTransform rt = icon.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(100, 100);
        rt.localScale = Vector3.one;
        rt.localPosition = Vector3.zero;

        img.color = Color.white; 
    }
}
