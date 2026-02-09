using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootInterval = 0.4f;
    public float range = 8f;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        Transform target = FindNearestZombie();
        if (target == null) return;

        AimAt(target);

        if (timer >= shootInterval)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            timer = 0;
        }
    }

    void AimAt(Transform target)
    {
        Vector2 dir = target.position - firePoint.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
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
