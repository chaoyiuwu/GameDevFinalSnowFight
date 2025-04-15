using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 5.0f;
    public GameObject snowballPrefab;
    private Vector2 moveValue;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    enum Direction {
        Up,
        Down,
        Left,
        Right
    }
    private Direction currentDirection = Direction.Down;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        Move();
    }

    public void OnAttack(InputAction.CallbackContext ctx) {
        if(ctx.performed) {
            GameObject snowball = Instantiate(snowballPrefab, transform.position, transform.rotation);

            Rigidbody2D snowballRb = snowball.GetComponent<Rigidbody2D>();
            if (snowballRb != null) {
                switch(currentDirection) {
                    case Direction.Up:
                        snowballRb.linearVelocity = Vector3.up;
                        break;
                    case Direction.Down:
                        snowballRb.linearVelocity = Vector3.down;
                        break;
                    case Direction.Left:
                        snowballRb.linearVelocity = Vector3.left;
                        break;
                    default:
                        snowballRb.linearVelocity = Vector3.right;
                        break;
                }
            }
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        moveValue = ctx.ReadValue<Vector2>();
        if (moveValue.magnitude > 0) {
            if (moveValue.y > 0) {
                currentDirection = Direction.Up;
            } else if (moveValue.y < 0) {
                currentDirection = Direction.Down;
            } else if (moveValue.x > 0) {
                currentDirection = Direction.Right;
            } else if (moveValue.x < 0) {
                currentDirection = Direction.Left;
            }
        }
    }

    private void Move() {
        if (animator != null) {
            if (moveValue.magnitude > 0) {
                // transitions animation to running state
                animator.SetBool("isMoving", true);
                // updates animation based on direction
                animator.SetFloat("horizontal", moveValue.x);
                animator.SetFloat("vertical", moveValue.y);

                spriteRenderer.flipX = moveValue.x > 0f;

                transform.Translate(new Vector3(moveValue.x, moveValue.y, 0) * speed * Time.deltaTime);
            }
            else {
                // transitions animation to idle state
                animator.SetBool("isMoving", false);
            }
        } 
    }
}
