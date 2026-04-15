using UnityEngine;

public class BossAI : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 1.5f;

    [Header("Stomp Attack")]
    public float attackCooldown = 4f;
    public float attackRange = 2f;
    public int damage = 1;

    [Header("HP")]
    public int maxHP = 100;
    int currentHP;

    [Header("Effects")]
    public GameObject stompEffect;

    float attackTimer;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        currentHP = maxHP;
        Debug.Log("BOSS hp START!");
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            Stomp();
            attackTimer = 0f;
        }
    }

    void Stomp()
    {
        if (player == null) return;

        if (stompEffect != null)
        {
            Instantiate(stompEffect, transform.position, Quaternion.identity);
        }

        StartCoroutine(ScreenShake());

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= attackRange)
        {
            player.GetComponent<PlayerLife>()?.TakeDamage(damage);
        }

        Debug.Log("BOSS STOMP!");
    }

    public void TakeDamage(int dmg)
    {
        Debug.Log("BOSS took damage!");
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.instance?.BossKilled();
        Destroy(gameObject);
    }
    public int GetHP()
    {
        return currentHP;
    }

    System.Collections.IEnumerator ScreenShake()
    {
        Vector3 startPos = Camera.main.transform.localPosition;

        float duration = 0.2f;
        float time = 0f;

        while (time < duration)
        {
            float strength = 0.1f;

            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);

            Camera.main.transform.localPosition = startPos + new Vector3(x, y, 0) * strength;

            time += Time.deltaTime;
            yield return null;
        }

        Camera.main.transform.localPosition = startPos;
    }
}
