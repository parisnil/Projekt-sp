using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Wave Settings")]
    public int currentLevel = 1;
    public int zombiesToNextLevel = 10;
    public float pauseTime = 2f;

    public ZombieSpawnManager spawnManager;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        spawnManager.StartWave(currentLevel, zombiesToNextLevel);
    }

    public void NextWave()
    {
        StartCoroutine(LevelUpRoutine());
    }

    private IEnumerator LevelUpRoutine()
    {
        Debug.Log("Wave klar! Level " + currentLevel);

        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(pauseTime);
        Time.timeScale = 1f;

        currentLevel++;
        zombiesToNextLevel += 5;

        spawnManager.StartWave(currentLevel, zombiesToNextLevel);

        Debug.Log("Level " + currentLevel + " startar!");
    }
}
