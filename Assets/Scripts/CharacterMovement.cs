using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
  [Header("Horizontal Movement")]
  [SerializeField] private float movementSpeed;
  [SerializeField] private float maxSpeed;
  [Tooltip("Controlls how long it takes for the player to come to a stop")]
  [Range(0.0f, 1.0f)]
  [SerializeField] private float dragLerp;
  [Tooltip("Whether or not the character moves in the opposite horizontal direction inputted by the player")]
  [SerializeField] private bool isMirrored;


  [Header("Verticle Movement")]
  [SerializeField] private float jumpForce;
  [Tooltip("The layermask that specifies what type of ground we're able to jump off of")]
  [SerializeField] private LayerMask jumpableGround;

  private bool hasControl;

  private Rigidbody2D rb;
  private SpriteRenderer sprite;
  private BoxCollider2D boxCollider;

  // Start is called before the first frame update
  void Start()
  {
    hasControl = true;

    GameStateManager.OnDeath += OnDeath;
    GameStateManager.OnWin += OnWin;
    GameStateManager.OnTogglePause += OnTogglePause;

    rb = this.GetComponent<Rigidbody2D>();
    sprite = this.GetComponent<SpriteRenderer>();
    boxCollider = this.GetComponent<BoxCollider2D>();
  }

  void OnDeath()
  {
    hasControl = false;
    rb.velocity = Vector2.zero;
    Debug.Log("I died!");
  }

  void OnWin()
  {
    hasControl = false;
    rb.velocity = Vector2.zero;
    Debug.Log("I won!");
  }

  void OnTogglePause()
  {
    hasControl = !hasControl;
  }

  void Update()
  {
    if (hasControl)
    {
      CheckHorizontalMovement();
      CheckForJump();
    }
  }

  void CheckHorizontalMovement()
  {
    // Flip the sprite in the direction we're facing. This should happen after all the velocity calcualtions
    if (Input.GetButton("Horizontal"))
    {
      // Moving horizontally
      float horizontalVelocity = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
      horizontalVelocity = isMirrored ? -horizontalVelocity : horizontalVelocity;
      if (Mathf.Abs(horizontalVelocity) > maxSpeed)
      {
        horizontalVelocity = maxSpeed * Mathf.Sign(horizontalVelocity);
      }
      rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);

      // Flip the sprite in the direction we're facing. This should happen after all the velocity calcualtions
      sprite.flipX = (Mathf.Sign(rb.velocity.x) == 1.0f) ^ isMirrored;
    }
    else
    {
      // Apply drag
      rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, dragLerp), rb.velocity.y);
    }
  }

  void CheckForJump()
  {
    if (Input.GetButtonDown("Jump") && isGrounded())
    {
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
  }

  /*
      Source: https://www.youtube.com/watch?v=ptvK4Fp5vRY
  */
  private bool isGrounded()
  {
    RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    return hit.collider != null;
  }
}
