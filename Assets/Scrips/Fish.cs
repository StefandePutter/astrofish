using UnityEngine;
using UnityEngine.InputSystem;

public class Fish : MonoBehaviour
{
    public Vector2 mousePos;
    public bool isBubbled = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnMousePosition(InputValue value)
    {
        mousePos = value.Get<Vector2>();
    }
}
