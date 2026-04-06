using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public float radius = 3f;
    public int damage = 999;

    public GameObject explosionFX;

    public void Explode()
    {
        if (explosionFX != null)
        {
            Instantiate(explosionFX, transform.position, Quaternion.identity);
        }

        Debug.Log("BOOM!");

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Zombie"))
            {
                ZombieHealth z = hit.GetComponent<ZombieHealth>();

                if (z != null)
                {
                    z.TakeDamage(damage);
                }
            }
        }
    }
}
