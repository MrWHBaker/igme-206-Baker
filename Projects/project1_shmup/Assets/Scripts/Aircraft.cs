using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Aircraft : CollidableObject
{
    // ======== FIELDS ============================================================================
    public int health;
    [SerializeField]
    protected Vector3 velocity;

    // ======== METHODS ===========================================================================

    // Method to fire bullets
    protected abstract void Attack();
    //protected abstract void TakeHit();
    
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    
}
