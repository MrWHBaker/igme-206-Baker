using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Wanderer : Agent
{
    [Min(1f)]
    public float stayInBoundsWeight = 3f;

    public float wanderWeight = 1f;

    public float avoidanceWeight = 3f;


    // Steering force
    protected override void CalcSteeringForces()
    {
        Vector3 ultimateForce = Vector3.zero;
        ultimateForce += Wander(wanderWeight);
        ultimateForce += StayInBounds(stayInBoundsWeight);
        ultimateForce += AvoidObsticle(avoidanceWeight);
        Vector3.ClampMagnitude(ultimateForce, maxForce);

        physicsObject.ApplyForce(ultimateForce);
    }

}
