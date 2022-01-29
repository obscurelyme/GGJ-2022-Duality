using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxSpeed;
    [Tooltip("Whether or not the character moves in the opposite horizontal direction inputted by the player")]
    [SerializeField] private bool isMirrored;

    [Header("Verticle Movement")]
    [SerializeField] private float jumpForce;
    [Tooltip("The layermask that specifies what type of ground we're able to jump off of")]
    [SerializeField] private LayerMask jumpableGround;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sprite = this.GetComponent<SpriteRenderer>();
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        CheckHorizontalMovement();
        CheckForJump();
    }

    void CheckHorizontalMovement()
    {
        // Moving horizontally
        float horizontalVelocity = Input.GetAxis("Horizontal") * movementSpeed;
        horizontalVelocity = isMirrored ? -horizontalVelocity : horizontalVelocity;
        if (Mathf.Abs(horizontalVelocity) > maxSpeed) {
            horizontalVelocity = maxSpeed * Mathf.Sign(horizontalVelocity);
        }
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);

        // Flip the sprite in the direction we're facing. This should happen after all the velocity calcualtions
        if (Input.GetButton("Horizontal")) {
            sprite.flipX = (Mathf.Sign(rb.velocity.x) == 1.0f) ^ isMirrored;
        }
    }

    void CheckForJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    /*
        Source: https://www.youtube.com/watch?v=ptvK4Fp5vRY
    */
    private bool isGrounded() {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        return hit.collider != null;
    }
}
