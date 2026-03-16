using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
    [Header("Zombie Prefabs")]
    public GameObject normalZombiePrefab;
    public GameObject strongZombiePrefab;

    [Header("Spawn Settings")]
    public float initialSpawnInterval = 5f;   
    public float minSpawnInterval = 1.5f;    
    public float spawnAcceleration = 0.05f;   
    public int startStrongAfter = 20;   
    public int fullStrongAt = 50;   

    [Header("Map Area")]
    public float minX, maxX, minY, maxY;

    private int totalZombiesSpawned = 0;
    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        Invoke(nameof(SpawnZombie), currentSpawnInterval);
    }

    void SpawnZombie()
    {
        GameObject prefabToSpawn = normalZombiePrefab;

        if (totalZombiesSpawned >= startStrongAfter)
        {
            float strongChance = Mathf.Clamp01((float)(totalZombiesSpawned - startStrongAfter) / (fullStrongAt - startStrongAfter));

            if (Random.value < strongChance)
            {
                prefabToSpawn = strongZombiePrefab;
            }
        }

        Vector2 spawnPos = new Vector2(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY)
        );

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);

        totalZombiesSpawned++;

        currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - spawnAcceleration);

        Invoke(nameof(SpawnZombie), currentSpawnInterval);
    }
}
