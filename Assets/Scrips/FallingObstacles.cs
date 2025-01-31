using System.Security.Cryptography;
using UnityEngine;

public class FallingObstacles : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;
    private bool falling;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

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
            transform.position = transform.position + Vector3.down*fallSpeed;
        }
    }
}
