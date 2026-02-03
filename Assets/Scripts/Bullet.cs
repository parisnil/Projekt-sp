using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public float lifeTime = 3f;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            other.GetComponent<ZombieHealth>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
