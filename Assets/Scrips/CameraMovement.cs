using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(-4, 0, -10);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private GameObject player;
    void Update()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, player.transform.position.y+3.5, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
