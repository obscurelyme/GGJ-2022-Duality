using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;

    // Used to check if we can jump or not
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
        // Checking for button input prevents the drag force from making the sprite dance
        if (Input.GetButton("Horizontal")) {
            sprite.flipX = Mathf.Sign(rb.velocity.x) == 1.0f;
        }

        // Moving horizontally
        float horizontalVelocity = Input.GetAxis("Horizontal") * movementSpeed;
        if (Mathf.Abs(horizontalVelocity) > maxSpeed) {
            horizontalVelocity = maxSpeed * Mathf.Sign(horizontalVelocity);
        }
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);

        // Jumping
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
