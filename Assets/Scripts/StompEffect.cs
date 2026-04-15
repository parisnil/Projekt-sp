using UnityEngine;

public class StompEffect : MonoBehaviour
{
    public float expandSpeed = 12f;
    public float lifeTime = 0.4f;

    public float damageRadius = 5f;
    public int damage = 1;

    LineRenderer lr;
    float currentRadius;

    Transform player;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 60;

        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        currentRadius += expandSpeed * Time.deltaTime;

        DrawCircle(currentRadius);

        CheckDamage();
    }

    void CheckDamage()
    {
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= currentRadius && dist >= currentRadius - 0.5f)
        {
            player.GetComponent<PlayerLife>()?.TakeDamage(damage);
        }
    }

    void DrawCircle(float radius)
    {
        for (int i = 0; i < lr.positionCount; i++)
        {
            float angle = i * Mathf.PI * 2f / lr.positionCount;

            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            lr.SetPosition(i, transform.position + new Vector3(x, y, 0));
        }
    }
}
