using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fleer : Agent
{
    // Target to seek
    [SerializeField]
    private Agent target;


    // Steering force
    protected override void CalcSteeringForces()
    {
        Flee(target.myPos);

        // Check for collisions and teleport somewhere random
        if ((target.myPos - myPos).magnitude < target.radius + radius)
        {
            physicsObject.Position = new Vector3(Random.Range(-8, 8), Random.Range(-5, 5), 0f);
        }
    }

    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new protected void Update()
    {
        base.Update();
    }
}
