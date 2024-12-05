using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UFO : Aircraft
{
    // ======== FIELDS ============================================================================
    //MovementController controller;
    //Vector3 velocity = Vector3.zero;

    // ======== METHODS ===========================================================================

    protected override void Attack()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            enemyManager.NewBullet(false, transform.position, 0);
        }
    }

    
    // Start is called before the first frame update
    /*
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
