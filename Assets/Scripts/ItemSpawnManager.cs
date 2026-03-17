using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject lootBoxPrefab;
    public GameObject healthPrefab;
    public GameObject magnetPrefab;

    [Header("Spawn Settings")]
    public float directItemSpawnInterval = 5f;
    public float lootBoxSpawnInterval = 8f;

    public int maxDirectItems = 6; 
    public int maxLootBoxes = 2;  

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;

        InvokeRepeating(nameof(SpawnDirectItem), 2f, directItemSpawnInterval);
        InvokeRepeating(nameof(SpawnLootBox), 3f, lootBoxSpawnInterval);
    }

    void SpawnDirectItem()
    {
        int currentDirectItems =
            GameObject.FindGameObjectsWithTag("Health").Length +
            GameObject.FindGameObjectsWithTag("Magnet").Length;

        if (currentDirectItems >= maxDirectItems) return;

        Vector2 spawnPos = GetRandomPositionOnMap();

        GameObject prefabToSpawn =
            (Random.value < 0.7f) ? healthPrefab : magnetPrefab;

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }

    void SpawnLootBox()
    {
        if (GameObject.FindGameObjectsWithTag("LootBox").Length >= maxLootBoxes)
            return;

        if (Random.value > 0.25f) return; 

        Vector2 spawnPos = GetRandomPositionOnMap();
        Instantiate(lootBoxPrefab, spawnPos, Quaternion.identity);
    }

    Vector2 GetRandomPositionOnMap()
    {
        float camHeight = 2f * mainCam.orthographicSize;
        float camWidth = camHeight * mainCam.aspect;

        float spawnX = Random.Range(
            mainCam.transform.position.x - camWidth,
            mainCam.transform.position.x + camWidth
        );

        float spawnY = Random.Range(
            mainCam.transform.position.y - camHeight,
            mainCam.transform.position.y + camHeight
        );

        return new Vector2(spawnX, spawnY);
    }
}
