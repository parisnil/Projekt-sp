using UnityEngine;
using System.Collections;

public class ZombieSpawnManager : MonoBehaviour
{
    [Header("Zombie Prefabs")]
    public GameObject[] zombiePrefabs;

    [Header("Spawn Settings")]
    public float spawnInterval = 0.5f;

    private int zombiesToSpawn;
    private int zombiesAlive;
    private bool waveActive;

    public void StartWave(int level, int amount)
    {
        StopAllCoroutines();

        zombiesToSpawn = amount;
        zombiesAlive = amount;
        waveActive = true;

        StartCoroutine(SpawnWave(level));
    }

    IEnumerator SpawnWave(int level)
    {
        for (int i = 0; i < zombiesToSpawn; i++)
        {
            int index = Mathf.Clamp(level - 1, 0, zombiePrefabs.Length - 1);
            GameObject prefab = zombiePrefabs[index];

            Vector2 spawnPos = GetSpawnOutsideCamera();

            Instantiate(prefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void ZombieDied()
    {
        zombiesAlive--;

        if (zombiesAlive <= 0 && waveActive)
        {
            waveActive = false;
            GameManager.instance.NextWave();
        }
    }

    Vector2 GetSpawnOutsideCamera()
    {
        Camera cam = Camera.main;

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        Vector2 camPos = cam.transform.position;

        float spawnDistance = 2f;

        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0: 
                return new Vector2(
                    camPos.x - width / 2 - spawnDistance,
                    Random.Range(camPos.y - height / 2, camPos.y + height / 2)
                );

            case 1:
                return new Vector2(
                    camPos.x + width / 2 + spawnDistance,
                    Random.Range(camPos.y - height / 2, camPos.y + height / 2)
                );

            case 2:
                return new Vector2(
                    Random.Range(camPos.x - width / 2, camPos.x + width / 2),
                    camPos.y + height / 2 + spawnDistance
                );

            default: 
                return new Vector2(
                    Random.Range(camPos.x - width / 2, camPos.x + width / 2),
                    camPos.y - height / 2 - spawnDistance
                );
        }
    }
}
