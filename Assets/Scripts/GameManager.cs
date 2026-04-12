using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Wave Settings")]
    public int currentLevel = 1;
    public int zombiesToNextWave = 20;
    public float pauseTime = 10f;
    public int maxWaves = 3;

    [Header("References")]
    public ZombieSpawnManager spawnManager;
    public GameObject upgradePanel;
    public AudioClip winSound;

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

    void WinGame()
    {
        MusicManager.instance?.StopMusic();

        if (winSound != null)
        {
            AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
        }

        Debug.Log("YOU WIN!");

        FindFirstObjectByType<VictoryScreenUI>()?.Show();
    }

    IEnumerator WaveRoutine()
    {
        waitingForWave = true;

        spawnManager.StopAllCoroutines();

        currentLevel++;

        if (currentLevel > maxWaves)
        {
            waitingForWave = false;
            WinGame();
            yield break;
        }

        if (upgradePanel != null)
            upgradePanel.SetActive(true);

        yield return new WaitForSeconds(pauseTime);

        if (upgradePanel != null)
            upgradePanel.SetActive(false);

        FindFirstObjectByType<UpgradeManager>()?.ResetChoices();

        zombiesToNextWave = 20;
        FindFirstObjectByType<SpriteCounter>()?.ResetCount(zombiesToNextWave);

        waitingForWave = false;

        StartWave();
    }
}
