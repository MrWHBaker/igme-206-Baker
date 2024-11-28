using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PhysicsObject : MonoBehaviour
{
    // ======== FIELDS =============================================================================

    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;
    //private Quaternion rotation;

    [SerializeField]
    private float mass;

    [SerializeField]
    public float radius;

    // External force detail
    [SerializeField]
    private bool hasFriction = false;
    [SerializeField]
    private float frictionCoeff;

    [SerializeField]
    private bool hasGravity;
    private float gravityStrength = 1f;

    private float maxSpeed;


    public Vector3 Position
    {
        get { return position; }
        set { position = value; }
    }

    public Vector3 Velocity
    {
        get { return velocity; }
    }


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
    private void ApplyRotation()
    {

        float rotAngle = 360 -(Mathf.Atan2(velocity.x, velocity.y) * Mathf.Rad2Deg);
        Quaternion rotation = Quaternion.Euler(0, 0, rotAngle);

        transform.rotation = rotation;
    }
    

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

    // Method to apply a provided force
    public void ApplyForce(Vector3 force)
    {
        acceleration += (force / mass);
    }


    // ======== Standard behavior ================================================================
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Use applied forces to update position and direction
        if (hasGravity) { ApplyGravity(); }
        if (hasFriction) { ApplyFriction(); }




        velocity += acceleration * Time.deltaTime;

        // Bounce!
        Bounce();

        position += velocity * Time.deltaTime;

        direction = velocity.normalized;

        position.z = 0f;
        transform.position = position;

        // Reset accelleration
        acceleration = Vector3.zero;

        // Apply rotation
        ApplyRotation();

    }
}

//