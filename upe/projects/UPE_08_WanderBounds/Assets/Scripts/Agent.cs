using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    protected PhysicsObject physicsObject;
    [SerializeField]
    protected float maxSpeed;
    [SerializeField]
    protected float maxForce;

    public Vector3 myPos = new Vector3(0,0,0);

    public float radius;

    public float wanderRadius = 2;
    [SerializeField]
    private float wanderAngle = 0f;
    private float maxWanderAngle = 90;
    private float maxWanderChangePerSecond = 45f;

    public Vector3 cameraSize = new Vector3 (8, 5, 0);


    // Method to call a child's steering force ====================================================
    protected abstract void CalcSteeringForces();

    // Method to seek a target
    protected Vector3 Seek(Vector3 targetPos, float weight = 1)
    {
        // Calculate desired velocity and scale it to max speed
        Vector3 desiredVelocity = targetPos - physicsObject.Position;
        desiredVelocity.Normalize();
        desiredVelocity *= maxSpeed;

        // Calculate steering force as toward the end of desired velocity
        Vector3 steeringForce = desiredVelocity - physicsObject.Velocity;

        return(steeringForce * weight);
    }

    // Method to flee from a target
    protected void Flee(Vector3 targetPos)
    {
        // Calculate desired velocity and scale it to max speed
        Vector3 desiredVelocity = physicsObject.Position - targetPos;
        desiredVelocity.Normalize();
        desiredVelocity *= maxSpeed;

        // Calculate steering force as toward the end of desired velocity
        Vector3 steeringForce = desiredVelocity - physicsObject.Velocity;

        physicsObject.ApplyForce(steeringForce); 
    }


    // Method to wander at random =================================================================
    protected Vector3 Wander(float time = 1f, float weight = 1f)
    {
        // Update the angle of our current wander
        float maxWanderChange = maxWanderChangePerSecond * Time.deltaTime;
        // Choose a distance ahead
        Vector3 futurePos = GetFuturePosition(time);

        //Get a random angle to determine displacement vector
        float randAngle = Random.Range(-maxWanderChange, maxWanderChange);
        wanderAngle += randAngle;

        wanderAngle = Mathf.Clamp(wanderAngle, -maxWanderAngle, maxWanderAngle);

        
        // displacement defined by wander angle
        Vector3 targetPos = futurePos;
        targetPos.x += Mathf.Sin(wanderAngle) * wanderRadius;
        targetPos.y += Mathf.Cos(wanderAngle) * wanderRadius;

        return Seek(targetPos);
    }


    // Method to get a future position ============================================================
    public Vector3 GetFuturePosition(float time = 1f)
    {
        return (physicsObject.Velocity * time) + myPos;
    }


    // Method to keep an agent within the bounds of the scene =====================================
    protected Vector3 StayInBounds(float weight = 1)
    {
        Vector3 futurePosition = GetFuturePosition();

        if (Mathf.Abs(futurePosition.x) > cameraSize.x ||
            Mathf.Abs(futurePosition.y) > cameraSize.y)
        {
            return Seek(Vector3.zero, weight);
        }

        return Vector3.zero;
    }

    // Start is called before the first frame update
    protected void Start()
    {
        physicsObject = GetComponent<PhysicsObject>();

        myPos = physicsObject.Position;
        radius = physicsObject.radius;

        // Calculate a random angle to start wandering toward
        wanderAngle = Random.Range(0, 2 * Mathf.PI);
    }

    // Update is called once per frame
    protected void Update()
    {
        myPos = physicsObject.Position;
        CalcSteeringForces();
    }
}
