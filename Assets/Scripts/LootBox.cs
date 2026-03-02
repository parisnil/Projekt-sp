using UnityEngine;

public class LootBox : MonoBehaviour
{
    public GameObject[] possibleBagItems;
    public Transform spawnPoint;
    private bool opened = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (opened) return;
        if (other.CompareTag("Player"))
        {
            Open();
        }
    }

    void Open()
    {
        opened = true;
        Debug.Log("OpenLootBox");
        int index = Random.Range(0, possibleBagItems.Length);
        Instantiate(possibleBagItems[index], spawnPoint.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
