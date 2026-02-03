using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 move;

    private bool isKnocked = false;
    private Vector2 knockbackVelocity;
    public float knockbackPower = 6f;
    public float knockbackDuration = 0.15f;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        move = Vector2.zero;
        if (Keyboard.current.wKey.isPressed) move.y += 1;
        if (Keyboard.current.sKey.isPressed) move.y -= 1;
        if (Keyboard.current.aKey.isPressed) move.x -= 1;
        if (Keyboard.current.dKey.isPressed) move.x += 1;

        bool isMoving = move.sqrMagnitude > 0.01f;
        animator.SetBool("IsMoving", isMoving);

        if (move.x > 0.01f) spriteRenderer.flipX = false;
        else if (move.x < -0.01f) spriteRenderer.flipX = true;
    }

    void FixedUpdate()
    {
        if (isKnocked)
        {
            rb.MovePosition(
                rb.position + knockbackVelocity * Time.fixedDeltaTime
            );
            return;
        }

        if (move.sqrMagnitude > 0.01f)
        {
            Vector2 newPos =
                rb.position + move.normalized * speed * Time.fixedDeltaTime;

            rb.MovePosition(newPos);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Krock");
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Debug.Log("Player hit by enemy!");
            Knockback(collision);    
        }
    }

    void Knockback(Collision2D collision)
    {
        Vector2 dir =
            (rb.position - (Vector2)collision.transform.position).normalized;

        knockbackVelocity = dir * knockbackPower;

        StopAllCoroutines();
        StartCoroutine(KnockbackRoutine());
    }

    System.Collections.IEnumerator KnockbackRoutine()
    {
        isKnocked = true;

        yield return new WaitForSeconds(knockbackDuration);

        isKnocked = false;
    }


}
