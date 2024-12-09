using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UFO : Aircraft
{
    // ======== FIELDS ============================================================================
    private MovementController controller;
    Vector3 velocity;

    // ======== METHODS ===========================================================================

    protected override void Attack()
    {
        //float velocityMod = Mathf.Sign(velocity.y);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            enemyManager.NewBullet(false, transform.position, velocity.y * 10);
        }
    }

    
    // Start is called before the first frame update
    
    protected override void Start()
    {
        controller = GetComponent<MovementController>();
        base.Start();
    }

    
    // Update is called once per frame
    protected override void Update()
    {
        velocity = controller.velocity;
        base.Update();
    }
    
}
