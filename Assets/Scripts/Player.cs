using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isGrounded;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {
        Jump();   
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocityY = jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
