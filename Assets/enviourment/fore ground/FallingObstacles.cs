using System.Security.Cryptography;
using UnityEngine;

public class FallingObstacles : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 0.5f;
    private bool falling;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject,1f);
            collision.rigidbody.AddForce(Vector2.down * 500);

            PlayerState state = collision.collider.GetComponent<Fish>().state;
            if (state == PlayerState.flying)
            {
                state = PlayerState.falling;
            }
        }
    }

    private void OnBecameInvisible()
    {
        if (falling)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameVisible()
    {
        falling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            rb.gravityScale = fallSpeed;
        }
    }
}
