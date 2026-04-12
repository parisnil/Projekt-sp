using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Setup")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource audioSource;
    public AudioClip shootSound;

    [Header("Stats")]
    public float shootInterval = 0.4f;
    public float range = 8f;
    public int damage = 1;

    float timer;

    Quaternion startRotation;

    void Start()
    {
        startRotation = transform.localRotation;
    }

    void Update()
    {
        if (firePoint == null || bulletPrefab == null) return;

        timer += Time.deltaTime;

        Transform target = FindNearestZombie();

        if (target != null)
        {
            AimAt(target);

            if (timer >= shootInterval)
            {
                Shoot();
                timer = 0f;
            }
        }
        else
        {
            ResetGun();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        if (audioSource != null && shootSound != null)
        {
            Debug.Log("SHOOT CALLED");

            audioSource.PlayOneShot(shootSound);
        }

        Bullet b = bullet.GetComponent<Bullet>();
        if (b != null)
        {
            b.damage = damage;
        }
    }

    void AimAt(Transform target)
    {
        Vector2 dir = target.position - firePoint.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void ResetGun()
    {
        transform.localRotation = startRotation;
    }

    Transform FindNearestZombie()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");

        float minDist = Mathf.Infinity;
        Transform closest = null;

        foreach (GameObject z in zombies)
        {
            float d = Vector2.Distance(transform.position, z.transform.position);

            if (d < minDist && d <= range)
            {
                minDist = d;
                closest = z.transform;
            }
        }

        return closest;
    }
}
