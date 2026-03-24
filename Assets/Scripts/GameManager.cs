using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Wave Settings")]
    public int currentLevel = 1;
    public int zombiesToNextLevel = 20;
    public float pauseTime = 10f;

    public ZombieSpawnManager spawnManager;

    [Header("Upgrade UI")]
    public GameObject upgradePanel;

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

        spawnManager.StopAllCoroutines();

        if (upgradePanel != null)
            upgradePanel.SetActive(true);

        yield return new WaitForSeconds(pauseTime);

        if (upgradePanel != null)
            upgradePanel.SetActive(false);

        currentLevel++;
        zombiesToNextLevel = 20;

        SpriteCounter counter = FindFirstObjectByType<SpriteCounter>();
        if (counter != null)
            counter.ResetCount(zombiesToNextLevel);

        spawnManager.StartWave(currentLevel, zombiesToNextLevel);

        Debug.Log("Level " + currentLevel + " startar!");
    }

    public void ZombieKilled()
    {
        SpriteCounter counter = FindFirstObjectByType<SpriteCounter>();
        if (counter != null)
            counter.AddCount();
    }
}
