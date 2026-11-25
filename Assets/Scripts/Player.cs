using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.7f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.linearVelocityY = jumpForce;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }
}
