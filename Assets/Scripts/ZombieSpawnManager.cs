using UnityEngine;
using System.Collections;

public class ZombieSpawnManager : MonoBehaviour
{
    [Header("Zombie Prefabs")]
    public GameObject[] zombiePrefabs; 

    [Header("Spawn Settings")]
    public float spawnInterval = 0.5f;
    public float minX, maxX, minY, maxY;

    private bool waveActive = false;

    public void StartWave(int level, int zombiesToSpawn)
    {
        if (waveActive) return;
        StartCoroutine(SpawnWave(level, zombiesToSpawn));
    }

    private IEnumerator SpawnWave(int level, int zombiesToSpawn)
    {
        waveActive = true;

        int index = Mathf.Clamp(level - 1, 0, zombiePrefabs.Length - 1);
        GameObject prefabToSpawn = zombiePrefabs[index];

        for (int i = 0; i < zombiesToSpawn; i++)
        {
            Vector2 spawnPos = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY)
            );

            Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }

        while (GameObject.FindGameObjectsWithTag("Zombie").Length > 0)
        {
            yield return null;
        }

        waveActive = false;

        GameManager.instance.NextWave();
    }
}
