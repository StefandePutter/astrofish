using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;

// interfaces
    // IDamageable
        // takeDamage function

// fish 
    // alle global variables
        // mousePos
        // health
        // falldamage based on speed
    // main function

    // fish shooter
        // cooldown 3 sec
        // shoot speed
        // shoot projectile
        // shoot kickback
        // shoot function
    
    // fish movement
        // MovementUpdate
        // bubbel script
        
// movingplatform
    // alles voor platform

// gamemanager
    // menu / pauze
    // checkpoints maybe?

// enemies
    // health
    // death
    // takeDamage function
    // damage function

// falling obstacles

// spikes


public class Input : MonoBehaviour
{
    public Vector2 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveValue = value.Get<Vector2>();
        Debug.Log(moveValue);
    }

    public void OnMousePosition(InputValue value)
    {
        mousePos = value.Get<Vector2>();    
    }

    public void OnAttack()
    {
        Debug.Log("Attack towards: " + mousePos);
    }

    public void TakeDamage(float damage)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
