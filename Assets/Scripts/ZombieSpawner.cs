using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    public float spawnInterval = 2f;
    public float spawnRadius = 10f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating(nameof(SpawnZombie), 1f, spawnInterval);
    }

    void SpawnZombie()
    {
        if (player == null) return;

        Vector2 randomDir = Random.insideUnitCircle.normalized;

        Vector2 spawnPos = (Vector2)player.position + randomDir * spawnRadius;

        Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
    }
}
