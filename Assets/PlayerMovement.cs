using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed

    [Header("Directional Sprites")]
    public Sprite downSprite; // Sprite for moving down
    public Sprite leftSprite; // Sprite for moving left
    public Sprite rightSprite; // Sprite for moving right
    public Sprite upSprite; // Sprite for moving up

    private Vector2 movement; // Movement vector
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    private void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
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
        // Move the character
        transform.Translate(movement * speed * Time.fixedDeltaTime);
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
