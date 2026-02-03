using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHP = 2;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
