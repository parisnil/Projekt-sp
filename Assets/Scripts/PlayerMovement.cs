using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 5f; 

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 move;

    private bool isKnocked;
    private Vector2 knockbackVelocity;
    public float knockbackPower = 6f;
    public float knockbackDuration = 0.15f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        move = Vector2.zero;
        if (Keyboard.current.wKey.isPressed) move.y += 1;
        if (Keyboard.current.sKey.isPressed) move.y -= 1;
        if (Keyboard.current.aKey.isPressed) move.x -= 1;
        if (Keyboard.current.dKey.isPressed) move.x += 1;

        animator.SetBool("IsMoving", move.sqrMagnitude > 0.01f);

        if (move.x > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (move.x < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void FixedUpdate()
    {
        if (isKnocked)
        {
            rb.MovePosition(rb.position + knockbackVelocity * Time.fixedDeltaTime);
            return;
        }

        if (move.sqrMagnitude > 0.01f)
        {
            float finalSpeed = baseSpeed;

            if (UpgradeManager.instance != null)
            {
                finalSpeed *= UpgradeManager.instance.speedMultiplier;
            }

            rb.MovePosition(rb.position + move.normalized * finalSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Vector2 dir = (rb.position - (Vector2)collision.transform.position).normalized;
            knockbackVelocity = dir * knockbackPower;
            StopAllCoroutines();
            StartCoroutine(KnockbackRoutine());
        }
    }

    System.Collections.IEnumerator KnockbackRoutine()
    {
        isKnocked = true;
        yield return new WaitForSeconds(knockbackDuration);
        isKnocked = false;
    }
}
