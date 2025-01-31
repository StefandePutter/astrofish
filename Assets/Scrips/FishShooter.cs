using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FishShooter : MonoBehaviour
{
    private Fish Fish;
    [SerializeField] private GameObject WaterShotPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float spawnDistance = 1000f;
    // [SerializeField] private Transform firepoint;
    private float nextFireTime = 0f;
    GameObject waterShot;

    void Start()
    {
        Fish = gameObject.GetComponent<Fish>(); 
    }

    void Update()
    {
        
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

            waterShot = Instantiate(WaterShotPrefab, temp.position, temp.rotation);
            
            Destroy(tempObj);


            nextFireTime = Time.time + 1f / fireRate;
        }
        
        Debug.Log("Attack towards: " + Fish.mousePos);


    }

    public void OnAttack() //set bool to false so shooting can be used
    {
        if (Fish.isBubbled == false)
        {
            Shoot();
        }
        else
        {
            Fish.isBubbled = false;
            Shoot();
        }
        Debug.Log(Time.time);

    }
}
