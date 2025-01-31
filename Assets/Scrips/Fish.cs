using UnityEngine;
using UnityEngine.InputSystem;

public class Fish : MonoBehaviour
{
    [HideInInspector] public Vector2 mousePos;
    [HideInInspector] public bool isBubbled;
    public bool walking;

    public float walkSpeed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Walkable"))
        {
            walking = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Walkable"))
        {
            walking = false;
        }
    }

    public void OnMousePosition(InputValue value)
    {
        mousePos = value.Get<Vector2>();
    }
}
