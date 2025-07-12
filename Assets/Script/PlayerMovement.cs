using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(KnockBack))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private PlayerController playerController;
    private BoxCollider2D coll;
    // private KnockBack knockBack;

    [Header("Jump Settings")]
    [SerializeField] private LayerMask jumpableGround;

    [Header("Health")]
    [SerializeField] private int maxHealth = 5;
    private int currentHealth;

    // [Header("Knockback Settings")]
    // [SerializeField] private float knockBackThrust = 10f;

    private float mobileInputX = 0f;
    private Vector2 moveInput;
    private bool isJumping = false;

    private enum MovementState { idle, walk, jump, fall, run }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        // knockBack = GetComponent<KnockBack>();

        playerController = new PlayerController();
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        playerController.Enable();

        playerController.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerController.Movement.Move.canceled += ctx => moveInput = Vector2.zero;
        playerController.Movement.Jump.performed += ctx => Jump();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }

    private void Update()
    {
        if (Application.isMobilePlatform)
        {
            moveInput = new Vector2(mobileInputX, 0f);
        }
        else
        {
            moveInput = playerController.Movement.Move.ReadValue<Vector2>();
        }

        if (isGrounded() && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            isJumping = false;
        }

        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        // if (knockBack.GettingKnockedBack) return;

        Vector2 targetVelocity = new Vector2((moveInput.x + mobileInputX) * moveSpeed, rb.velocity.y);
        rb.velocity = targetVelocity;
    }

    private void UpdateAnimation()
    {
        MovementState state;
        float horizontal = moveInput.x != 0 ? moveInput.x : mobileInputX;

        if (horizontal > 0f)
        {
            state = MovementState.walk;
            sprite.flipX = false;
        }
        else if (horizontal < 0f)
        {
            state = MovementState.walk;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void Jump()
    {
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }
    }

    // Public methods for mobile input
    public void MoveRight(bool isPressed)
    {
        mobileInputX = isPressed ? 1f : (mobileInputX == 1f ? 0f : mobileInputX);
    }

    public void MoveLeft(bool isPressed)
    {
        mobileInputX = isPressed ? -1f : (mobileInputX == -1f ? 0f : mobileInputX);
    }

    public void MobileJump()
    {
        if (isGrounded()) Jump();
    }

    // Knockback-aware TakeDamage
    public void TakeDamage(int damage, Transform damageSource)
    {
        // if (knockBack.GettingKnockedBack) return;

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Player Mati");
            // Tambahkan logic kematian jika perlu
        }

        // knockBack.GetKnockedBack(damageSource, knockBackThrust);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        // Placeholder: isi dengan update UI sesuai sistem UI kamu
        Debug.Log("HP: " + currentHealth + "/" + maxHealth);
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Enemy"))
    //     {
    //         foreach (ContactPoint2D contact in collision.contacts)
    //         {
    //             if (contact.normal.y < -0.5f)
    //             {
    //                 Debug.Log("Player menginjak musuh!");
    //                 rb.velocity = new Vector2(rb.velocity.x, jumpForce / 1.5f);
    //                 Destroy(collision.transform.root.gameObject);
    //                 return;
    //             }
    //             else
    //             {
    //                 Debug.Log("Player kena musuh dari samping.");
    //                 TakeDamage(1, collision.transform);
    //             }
    //         }
    //     }
    // }
}