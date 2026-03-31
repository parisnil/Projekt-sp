using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Wave Settings")]
    public int currentLevel = 1;
    public int zombiesToNextWave = 20;
    public float pauseTime = 10f;

    [Header("References")]
    public ZombieSpawnManager spawnManager;
    public GameObject upgradePanel;

    private bool waitingForWave = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartWave();
    }

    void StartWave()
    {
        spawnManager.StartWave(currentLevel, zombiesToNextWave);
    }

    public void ZombieKilled()
    {
        FindFirstObjectByType<SpriteCounter>()?.AddCount();
    }

    public void NextWave()
    {
        if (waitingForWave) return;
        StartCoroutine(WaveRoutine());
    }

    IEnumerator WaveRoutine()
    {
        waitingForWave = true;

        spawnManager.StopAllCoroutines();

        if (upgradePanel != null)
            upgradePanel.SetActive(true);

        yield return new WaitForSeconds(pauseTime);

        if (upgradePanel != null)
            upgradePanel.SetActive(false);

        FindFirstObjectByType<UpgradeManager>()?.ResetChoices();

        currentLevel++;
        zombiesToNextWave = 20;

        FindFirstObjectByType<SpriteCounter>()?.ResetCount(zombiesToNextWave);

        waitingForWave = false;

        StartWave();
    }
}
