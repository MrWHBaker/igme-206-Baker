using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    // Target to seek
    [SerializeField]
    private Agent target;


    // Steering force
    protected override void CalcSteeringForces()
    {
        Seek(target.myPos);
        //return Vector3.zero;
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
