using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    public int expAmount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerExperience playerExp = other.GetComponent<PlayerExperience>();
            if (playerExp != null)
            {
                playerExp.AddExp(expAmount);
            }

            Destroy(gameObject);
        }
    }
}
