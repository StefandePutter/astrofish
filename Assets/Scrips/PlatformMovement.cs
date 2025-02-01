using UnityEngine;
using UnityEngine.Windows;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float offset = 5f;
    [SerializeField] private bool isGoingLeft = false;
    private float scale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scale = transform.localScale.x;
        float lastnum = offset + 9.53f;
        offset = -9.53f * scale + lastnum;
        //offset = offset * (1 + (1-scale));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -offset)
        {
            isGoingLeft = false;
        } else if (transform.position.x >= offset)
        {
            isGoingLeft = true;
        }

        float speed = (isGoingLeft) ? -moveSpeed : moveSpeed;
        transform.Translate(speed * Vector3.right * Time.deltaTime, Space.World);
    }
}
