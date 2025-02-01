using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] bool facingRight;
    private Animator animator;
    private float attackTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > attackTimer)
        {
            animator.SetTrigger("Attack");
            float nextAttackTime = Random.Range(2, 4);
            attackTimer = Time.time + nextAttackTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            float pushback = 500;
            if (facingRight)
            {
                pushback *= -1;
            }

            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();
            playerRb.AddForce(new Vector2(-500,0));
        }
    }
}
