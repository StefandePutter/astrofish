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
        rb.gravityScale = fish.state == PlayerState.flying ? -1 : 1;

        if (fish.state == PlayerState.walking)
        {
            if (moveValue != Vector2.zero)
            {
                transform.Translate(fish.walkSpeed * Time.deltaTime * moveValue, Space.World);
            }
        }
        
    }

    public void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }


    public void OnBubble()
    {
        if (fish.state == PlayerState.walking)
        {
            rb.gravityScale = -1;
            fish.state = PlayerState.flying;
        }
        else if (fish.state == PlayerState.flying) 
        { 
            rb.gravityScale = 1;
            fish.state = PlayerState.falling;
        }
    }
}
