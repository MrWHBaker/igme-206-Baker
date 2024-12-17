using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UFO : Aircraft
{
    // ======== FIELDS ============================================================================
    private MovementController controller;
    [SerializeField]
    private TextMesh healthDisplay;


    // ======== METHODS ===========================================================================

    protected override void Attack()
    {

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            enemyManager.NewBullet(false, transform.position, velocity.y * 100);
        }

    }

    
    // Start is called before the first frame update
    
    protected override void Start()
    {
        controller = GetComponent<MovementController>();
        health = 5;
        base.Start();
    }

    
    // Update is called once per frame
    protected override void Update()
    {
        healthDisplay.text = ("Health: " + health);

        if (isHit) 
        { 
            health -= 1;
            isHit = false;
        }

        if (health <= 0)
        {
            controller.upSprite = null;
            controller.downSprite = null;
            controller.neutralSprite = null;

            enemyManager.spawning = false;
        }
        else
        {
            Attack();
        }

        velocity = controller.velocity;
        
        base.Update();
    }
    
}
