using UnityEngine;

public enum DirectItemType
{
    Health,
    Magnet
}

public class DirectItem : MonoBehaviour
{
    public DirectItemType type;

    public int healthAmount = 1;     
    public float magnetDuration = 5f; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (type == DirectItemType.Health)
        {
            PlayerLife life = other.GetComponent<PlayerLife>();
            if (life != null)
            {
                life.Heal(healthAmount);
            }
        }

        if (type == DirectItemType.Magnet)
        {
            PlayerMagnet magnet = other.GetComponent<PlayerMagnet>();
            if (magnet != null)
            {
                magnet.Activate(magnetDuration);
            }
        }

        Destroy(gameObject);
    }
}