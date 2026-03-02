using UnityEngine;
using System.Collections;

public class PlayerMagnet : MonoBehaviour
{
    public float magnetRadius = 5f;

    public void Activate(float duration)
    {
        StartCoroutine(MagnetRoutine(duration));
    }

    IEnumerator MagnetRoutine(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, magnetRadius);
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Exp"))
                {
                    hit.transform.position = Vector2.MoveTowards(hit.transform.position, transform.position, 10f * Time.deltaTime);
                }
            }
            timer += Time.deltaTime;
            yield return null;
        }
    }
}