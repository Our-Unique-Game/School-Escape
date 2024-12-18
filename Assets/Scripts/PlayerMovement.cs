using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed

    [Header("Directional Sprites")]
    [SerializeField] public Sprite downSprite; // Sprite for moving down
    [SerializeField] public Sprite leftSprite; // Sprite for moving left
    [SerializeField] public Sprite rightSprite; // Sprite for moving right
    [SerializeField] public Sprite upSprite; // Sprite for moving up

    [SerializeField] private Vector2 movement; // Movement vector
    [SerializeField] private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    [SerializeField] private Rigidbody2D rb; // Reference to the Rigidbody2D component

    // Movement enabled flag
    public bool CanMove { get; set; } = true;

    private void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!CanMove) // Disable input if movement is not allowed
        {
            movement = Vector2.zero;
            return;
        }

        // Get input for horizontal (A/D or Left/Right) and vertical (W/S or Up/Down) movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize the movement vector for consistent speed
        movement = movement.normalized;

        // Update the sprite based on the direction
        UpdateSprite();
    }

    private void FixedUpdate()
    {
        // Move the character using Rigidbody2D
        rb.linearVelocity = movement * speed;
    }

    private void UpdateSprite()
    {
        // Update the sprite based on the direction of movement
        if (movement.x > 0) // Moving right
        {
            spriteRenderer.sprite = rightSprite;
        }
        else if (movement.x < 0) // Moving left
        {
            spriteRenderer.sprite = leftSprite;
        }
        else if (movement.y > 0) // Moving up
        {
            spriteRenderer.sprite = upSprite;
        }
        else if (movement.y < 0) // Moving down
        {
            spriteRenderer.sprite = downSprite;
        }
    }
}
