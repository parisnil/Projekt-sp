using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;
    public AudioClip deathSound;

    [Header("Drop")]
    public GameObject expPrefab;
    public int expPerZombie = 2;
    public float spawnRadius = 0.3f; 

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }

        if (expPrefab != null)
        {
            for (int i = 0; i < expPerZombie; i++)
            {
                Vector2 offset = Random.insideUnitCircle * spawnRadius;
                Vector3 spawnPos = transform.position + new Vector3(offset.x, offset.y, 0);

                GameObject exp = Instantiate(expPrefab, spawnPos, Quaternion.identity);
                exp.GetComponent<ExpPickup>().expAmount = 1;
            }
        }

        GameManager.instance.ZombieKilled();

        ZombieSpawnManager spawner = FindFirstObjectByType<ZombieSpawnManager>();
        if (spawner != null)
        {
            spawner.ZombieDied();
        }

        Destroy(gameObject);
    }

}
