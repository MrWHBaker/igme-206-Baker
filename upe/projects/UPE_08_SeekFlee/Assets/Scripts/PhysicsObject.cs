using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    // ======== FIELDS =============================================================================
    
    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;

    [SerializeField]
    private float mass;

    // External force detail
    [SerializeField]
    private bool hasFriction = false;
    [SerializeField]
    private float frictionCoeff;

    [SerializeField]
    private bool hasGravity;
    private float gravityStrength = 1f;

    private float maxSpeed;


    MouseTracker mouseTracker;


    // ======== Force application methods ==========================================================

    // Method to apply the force of friction to an object
    private void ApplyFriction()
    {
        // Friction applies the opposite of velocity scaled to a friction coefficient
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction = friction * frictionCoeff;
        acceleration += friction/mass;
    }


    // Method to apply the force of gravty to an object
    private void ApplyGravity()
    {
        // Gravity does not take mass into account
        acceleration.y -= gravityStrength;
    }

    // OPTIONAL apply rotation
    

    // Method to bounce off window edges
    private void Bounce()
    {
        float bounce = -0.9f;

        if (Mathf.Abs(position.y) > 5)
        {
            position.y = 5 * Mathf.Sign(position.y);
            velocity.y *= bounce;
        }

        if (Mathf.Abs(position.x) > 8 )
        {
            position.x = 8 * Mathf.Sign(position.x);
            velocity.x *= bounce;
        }    
    }



    // ======== Standard behavior ================================================================
    // Start is called before the first frame update
    void Start()
    {
        mouseTracker = GetComponent<MouseTracker>();
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Use applied forces to update position and direction
        if (hasGravity) { ApplyGravity(); }
        if (hasFriction) { ApplyFriction(); }

        // Apply a force toward the cursor
        //acceleration += mouseTracker.MousePuller(position)/mass;



        velocity += acceleration * Time.deltaTime;

        // Bounce!
        Bounce();

        position += velocity * Time.deltaTime;

        direction = velocity.normalized;

        position.z = 0f;
        transform.position = position;

        // Reset accelleration
        acceleration = Vector3.zero;

    }
}

//