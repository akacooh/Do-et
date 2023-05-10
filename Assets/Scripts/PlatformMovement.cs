using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
    private SpriteRenderer sRenderer;
    private Rigidbody2D rb;
    private Vector3 direction;
    private Animator animator;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context) {
        float value = context.ReadValue<float>();
        animator.SetFloat("Speed", Mathf.Abs(value));
        if (value < 0) {
            sRenderer.flipX = true;
        } else if (value > 0) {
            sRenderer.flipX = false;
        }
        direction.x = value;
    }

    public void Jump(InputAction.CallbackContext context) {
        bool isGrounded = Mathf.Abs(rb.velocity.y) < 0.001f;
        if ((context.performed) && (isGrounded)) {
            rb.AddForce(Vector2.up * jumpForce * Mathf.Sign(rb.gravityScale), ForceMode2D.Impulse);
        }
    }

    public void Interact(InputAction.CallbackContext context) {

    }


}
