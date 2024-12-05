using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : CollidableObject
{
    // ======== FIELDS ============================================================================
    Vector3 velocity;

    // ======== METHODS ===========================================================================
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */
    // Update is called once per frame
    protected override void Update()
    {
        transform.position += velocity;
        base.Update();
    }
    
}
