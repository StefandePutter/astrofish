using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float offset = 3.5f;
    [SerializeField] private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private GameObject player;
    void FixedUpdate()
    {
        PlayerState state = player.GetComponent<Fish>().state;
        if (state == PlayerState.falling)
        {
            offset = 0;
        }
        else
        {
            offset = 3.5f;
        }

        Vector3 targetPosition = new Vector3(transform.position.x, player.transform.position.y + offset, transform.position.z);



        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime * Time.deltaTime);
    }

    //[SerializeField] private Transform _target;
    //[SerializeField] private float _smoothing = 5;
    //[SerializeField] private float _maxDist = 2f;

    //private Vector3 _offset;

    //void Start()
    //{
    //    _offset = transform.position - _target.position;
    //}

    //void FixedUpdate()
    //{
    //    Vector3 targetCamPos;
    //    float dist = Vector3.Distance(transform.position, _target.position);
    //    if (dist > _maxDist)
    //    {
    //        Debug.Log("bigger");
    //        targetCamPos = _target.position + (_offset.normalized * _maxDist);
    //    }
    //    else
    //    {
    //        Debug.Log("smaller");
    //        targetCamPos = _target.position + (_offset.normalized * dist);
    //    }
    //    Debug.Log(targetCamPos);
    //     Vector3 lookDir = (_target.position).normalized;
    //     targetCamPos += lookDir * _maxDist * 0.5f;

    //    transform.position = Vector3.Lerp(transform.position, targetCamPos, _smoothing * Time.deltaTime);
    //}
}
