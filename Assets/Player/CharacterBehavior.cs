using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public float normalSpeed = 3f;
    public float sprintSpeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;

    protected Vector2 movement;
    protected Vector2 lastDirection;

    protected virtual void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0)
        {
            movement.x = horizontalInput;
            movement.y = 0;
        }
        else if (verticalInput != 0)
        {
            movement.y = verticalInput;
            movement.x = 0;
        }
        else
        {
            movement = Vector2.zero;
        }

        if (movement != Vector2.zero)
        {
            lastDirection = movement;
        }

        anim.SetFloat("Horizontal", lastDirection.x);
        anim.SetFloat("Vertical", lastDirection.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    protected virtual void FixedUpdate()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : normalSpeed;
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }
}
