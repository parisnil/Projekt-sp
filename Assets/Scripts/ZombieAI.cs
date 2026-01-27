using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ZombieAI : MonoBehaviour
{
    public float speed = 2f;
    public float avoidRadius = 1f;
    public float avoidStrength = 1.5f;

    private Rigidbody2D rb;
    private Transform player;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 moveDir = (player.position - transform.position).normalized;

        Vector2 avoidDir = Vector2.zero;
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, avoidRadius);
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != gameObject && hit.CompareTag("Zombie"))
            {
                Vector2 diff = (Vector2)(transform.position - hit.transform.position);
                float dist = diff.magnitude;
                if (dist > 0) avoidDir += diff.normalized / dist;
            }
        }

        Vector2 finalDir = (moveDir + avoidDir * avoidStrength).normalized;

        rb.MovePosition(rb.position + finalDir * speed * Time.fixedDeltaTime);

        if (finalDir.x > 0.01f) transform.localScale = new Vector3(1, 1, 1);
        else if (finalDir.x < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
    }
}
