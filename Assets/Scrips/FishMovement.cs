using UnityEngine;
using UnityEngine.InputSystem;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private float gravityScale = 1;
    [SerializeField] private float maxSpeed = 25;
    private Fish fish;
    private Vector2 moveValue;
    private Rigidbody2D rb;
    
    void Start()
    {
        fish = GetComponent<Fish>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocityY = Mathf.Clamp(rb.linearVelocityY, -maxSpeed, maxSpeed);
    }

    void Update()
    {
        rb.gravityScale = fish.state == PlayerState.flying ? -gravityScale : 1;

        //Debug.Log(rb.linearVelocity.y);


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
