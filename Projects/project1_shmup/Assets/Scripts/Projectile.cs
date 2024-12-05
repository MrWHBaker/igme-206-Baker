using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : CollidableObject
{
    // ======== FIELDS ============================================================================
    [SerializeField]
    public Vector3 velocity = new Vector3(5, 0, 0);
    public float verticalVelocityMod;

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

        if (Mathf.Abs(transform.position.x) > 8f)
        {
            Destroy(gameObject);
        }

        base.Update();
    }
    
}
