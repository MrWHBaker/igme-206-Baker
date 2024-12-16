using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : CollidableObject
{
    // ======== FIELDS ============================================================================
    private Vector3 velocity = new Vector3(8, 0, 0);
    public float verticalVelocityMod;
    public int damage = 1;

    // ======== METHODS ===========================================================================
    
    // Start is called before the first frame update
    protected override void Start()
    {
        velocity.y = verticalVelocityMod;

        if (isEnemy) { velocity.x *= -1; }
        else { transform.rotation = Quaternion.Euler(0, 0, 180);  }

        base.Start();
    }
    
    // Update is called once per frame
    protected override void Update()
    {
        transform.position += velocity * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) > 8f || isHit)
        {
            
            if (isEnemy) { enemyManager.collisionManager.projectilesEnemy.Remove(gameObject); }
            else { enemyManager.collisionManager.projectilesPlayer.Remove(gameObject); }
            
            Destroy(gameObject);
        }

        base.Update();
    }
    
}
