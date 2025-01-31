using UnityEngine;

public class Egel : MonoBehaviour
{
    private bool shot;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D m_Rigidbody;
            m_Rigidbody = GetComponent<Rigidbody2D>();
            m_Rigidbody.AddForce(Vector2.right * 500f);

            shot = true;

            //Destroy(gameObject, 5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.CompareTag("Player"))
       {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(500, -1000));

            PlayerState state = collision.collider.GetComponent<Fish>().state;
            if (state == PlayerState.flying)
            {
                state = PlayerState.falling;
            }
        }
    }

    private void OnBecameInvisible()
    {
        if (shot)
        {
            Destroy(gameObject);
        }
    }
}
