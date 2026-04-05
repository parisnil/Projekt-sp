using UnityEngine;

public class LootBox : MonoBehaviour
{
    public GameObject[] possibleBagItems;
    public Transform spawnPoint;
    private bool opened = false;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger händer");
        if (opened) return;
        if (other.CompareTag("Player"))
        {
            Open();
        }
    }

    void Open()
    {
        opened = true;

        if (animator != null)
        {
            animator.SetTrigger("OpenLootBox");
        }

        StartCoroutine(SpawnLootWithDelay(0.3f));
    }

    System.Collections.IEnumerator SpawnLootWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        int index = Random.Range(0, possibleBagItems.Length);
        Instantiate(possibleBagItems[index], spawnPoint.position, Quaternion.identity);

        Destroy(gameObject); 
    }
}