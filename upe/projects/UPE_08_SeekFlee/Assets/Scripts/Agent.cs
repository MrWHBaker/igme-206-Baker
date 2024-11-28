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

    // Method to call a child's steering force
    protected abstract void CalcSteeringForces();

    // Method to seek a target
    protected void Seek(Vector3 targetPos)
    {
        // Calculate desired velocity and scale it to max speed
        Vector3 desiredVelocity = targetPos - physicsObject.Position;
        desiredVelocity.Normalize();
        desiredVelocity *= maxSpeed;

        // Calculate steering force as toward the end of desired velocity
        Vector3 steeringForce = desiredVelocity - physicsObject.Velocity;

        physicsObject.ApplyForce(steeringForce);
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

    // Start is called before the first frame update
    protected void Start()
    {
        physicsObject = GetComponent<PhysicsObject>();

        myPos = physicsObject.Position;
        radius = physicsObject.radius;
    }

    // Update is called once per frame
    protected void Update()
    {
        myPos = physicsObject.Position;
        CalcSteeringForces ();
    }
}
