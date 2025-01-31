using System.Net.Sockets;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FishShooter : MonoBehaviour
{
    private Fish Fish;
    private Rigidbody2D rb;

    [SerializeField] private GameObject WaterShotPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float kickback = 100f;
    [SerializeField] private float spawnDistance = 1.5f;

    private float nextFireTime = 0f;

    private bool IsShooting = false;

    GameObject waterShot;

    void Start()
    {
        Fish = gameObject.GetComponent<Fish>(); 
    }

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Shoot() // shoot projectile and delay function
    { 
        if (Time.time >= nextFireTime)
        {
            //shoot function

            GameObject tempObj = new GameObject("Temp");
            Transform temp = tempObj.transform; // Get its transform
            temp.SetParent(transform);
            temp.position = transform.position;
            Vector3 mousePosition = Fish.mousePos;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

            temp.up = direction;

            Vector3 spawnPosition = transform.position + temp.up * spawnDistance;

            waterShot = Instantiate(WaterShotPrefab, spawnPosition, temp.rotation);

            // adding force
            rb.AddForce(-temp.up*kickback);
            
            Destroy(tempObj);


            nextFireTime = Time.time + 0.1f / fireRate;
        }
        
        Destroy(waterShot, 0.5f);

    }

    

    public void OnAttack() //set bool to false so shooting can be used
    {
        IsShooting = !IsShooting;
        if (Fish.state == PlayerState.flying)
        {
            Fish.state = PlayerState.falling;
            Shoot();
        }
        else
        {
            Shoot();
        }
        //Debug.Log("OnAtack activated/deactivated");
        
    }
}
