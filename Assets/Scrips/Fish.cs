using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    walking = 0,
    flying,
    falling,
    finish
}

public class Fish : MonoBehaviour
{
    [HideInInspector] public Vector2 mousePos;
    public PlayerState state;
    public Animator animator;

    public float walkSpeed = 5f;

    void Start()
    {
        state = PlayerState.walking;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isFlying = (state == PlayerState.flying);
        bool isFalling = (state == PlayerState.falling);
        bool isWalking = (state == PlayerState.walking);
        bool finished = (state == PlayerState.finish);

        animator.SetBool("Flying", isFlying);
        animator.SetBool("Falling", isFalling);
        animator.SetBool("Walking", isWalking);
        animator.SetBool("Finish", finished);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Walkable"))
        {
            if (state == PlayerState.flying)
            {
                state = PlayerState.falling;
            }

            if (state == PlayerState.falling) 
            { 
                state = PlayerState.walking;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Walkable"))
        {
            if (state == PlayerState.walking)
            { 
                state = PlayerState.falling;
            }
        }
    }

    public void OnMousePosition(InputValue value)
    {
        mousePos = value.Get<Vector2>();
    }
}
