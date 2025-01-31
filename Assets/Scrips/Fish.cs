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

    public float walkSpeed = 5f;

    void Start()
    {
        state = PlayerState.walking;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Walkable"))
        {
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
