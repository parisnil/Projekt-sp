using UnityEngine;
using System.Collections;

public class PlayerSpeed : MonoBehaviour
{
    public float boostMultiplier = 2f;
    public float duration = 3f;

    public void ActivateSpeedBoost()
    {
        StopAllCoroutines();
        StartCoroutine(SpeedRoutine());
    }

    IEnumerator SpeedRoutine()
    {
        PlayerStats.speedMultiplier *= boostMultiplier;

        yield return new WaitForSeconds(duration);

        PlayerStats.speedMultiplier /= boostMultiplier;
    }
}
