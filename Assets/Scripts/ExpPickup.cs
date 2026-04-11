using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    public int expAmount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerExperience xp = FindFirstObjectByType<PlayerExperience>();

        if (xp != null)
            xp.AddExp(expAmount);

        Destroy(gameObject);
    }
}
