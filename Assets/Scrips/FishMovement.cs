using UnityEngine;
using UnityEngine.InputSystem;

public class FishMovement : MonoBehaviour
{
    private Fish fish;
    private Vector2 moveValue;
    private Rigidbody2D rb;
    
    void Start()
    {
        fish = GetComponent<Fish>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (fish.walking)
        {
            if (moveValue != Vector2.zero)
            {
                //transform = moveValue*fish.walkSpeed;
                transform.Translate(fish.walkSpeed * Time.deltaTime * moveValue, Space.World);
                //rb.AddForceX(fish.walkSpeed * moveValue.x);

            }
        }
    }

    public void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
        Debug.Log(moveValue.x);
    }

    public void OnBubble()
    {
        rb.gravityScale *= -1;
        Debug.Log("bubble: " + (fish.walking ? "bubbled" : "not bubbled"));
    }
}
