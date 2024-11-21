using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    protected PhysicsObject physicsObject;
    protected float maxSpeed;
    protected float maxForce;

    protected Vector3 myPos;

    // Method to call a child's steering force
    protected abstract Vector3 CalcSteeringForces();

    // Method to seek a target
    protected Vector3 Seek(Vector3 targetPos)
    {
        Vector3 desiredVelocity = targetPos - myPos;
        

        return Vector3.zero; // TEMP
    }

    // Start is called before the first frame update
    void Start()
    {
        physicsObject = GetComponent<PhysicsObject>();
        myPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CalcSteeringForces ();
        //myPos = transform.position;
    }
}
