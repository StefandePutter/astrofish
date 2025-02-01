using System.Collections;
using System.Net.Sockets;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FishShooter : MonoBehaviour
{
    private Fish Fish;
    private Rigidbody2D rb;

    [SerializeField] private GameObject WaterShotPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float kickback = 10f;
    [SerializeField] private float spawnDistance = 0.2f;
    [SerializeField] private float executionTime = 0.1f;


    private float nextFireTime = 0f;

    [SerializeField] private bool IsShooting = false;
    private bool hasStartedShooting = false;

    GameObject waterShot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Fish = gameObject.GetComponent<Fish>();
    }
    void Update()
    {

        if (Fish.state == PlayerState.flying && IsShooting == true)
        {
            Fish.state = PlayerState.falling;
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
        else if (IsShooting == true)
        {
            Shoot();
        }
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


        }
        
        Destroy(waterShot, 0.5f);
    }

    

    public void OnAttack() //set bool to false so shooting can be used
    {
        if (!hasStartedShooting) // Start shooting if it's not already active
        {
            IsShooting = true;
            hasStartedShooting = true;
            StartCoroutine(ExecuteForTime(executionTime));
        }
        else
        {
            IsShooting = false; // Stop shooting if it's already active
        }
    }

    IEnumerator ExecuteForTime(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            if (IsShooting)
            {
                Shoot(); // Keep shooting within the time frame
            }
            timer += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        IsShooting = false; // Stop shooting after the execution time ends
        hasStartedShooting = false;
        Debug.Log("Execution time ended.");
    }
}

