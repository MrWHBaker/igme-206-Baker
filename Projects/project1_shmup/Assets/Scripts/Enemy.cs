using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : Aircraft
{
    // ======== FIELDS ============================================================================
    protected GameObject target;

    protected Vector3 acceleration = Vector3.zero;
    protected Vector3 position;
    protected float mass;
    protected float maxSpeed;

    [SerializeField]
    protected Sprite upSprite;
    [SerializeField]
    protected Sprite downSprite;
    [SerializeField]
    protected Sprite neutralSprite;

    protected bool shotReady = false;

    // ======== METHODS ===========================================================================
    // Render sprites for enemy objects in motion
    protected virtual void Animate()
    {
        if (velocity.y == 0) { spriteRenderer.sprite = neutralSprite; }

        else if (Mathf.Sign(velocity.y) == 1 ) { spriteRenderer.sprite = upSprite; }

        else if (Mathf.Sign(velocity.y) == -1) { spriteRenderer.sprite = downSprite; }
    }

    // An enemy type's main behavior
    protected abstract void Behavior();

    // Seek method
    protected Vector3 Seek(Vector3 targetPos, float weight = 1)
    {
        // Calculate desired velocity and scale it to max speed
        Vector3 desiredVelocity = targetPos - position;
        desiredVelocity.Normalize();
        desiredVelocity *= maxSpeed;

        // Calculate steering force as toward the end of desired velocity
        Vector3 steeringForce = desiredVelocity - velocity;

        return (steeringForce * weight);
    }

    // Repel from screen edges
    protected void StayInBounds(float weight = 1)
    {
        if (Mathf.Abs(position.y) > 5)
        {
            ApplyForce(Seek(new Vector3 (position.x, 0, position.z), weight));
        }
    }

    protected void Bounce(float bounceMod = 1)
    {
        if (Mathf.Abs(position.y) > 5)
        {
            velocity.y = -velocity.y * bounceMod;
        }
    }


    // General method to apply a force toward the player's location to be used in different ways
    protected void FollowPlayerY(float weight)
    {
        float targetY = target.transform.position.y;
        float distance = position.y - targetY;

        if (Mathf.Abs(distance) > 1)
        {
            Vector3 targetPos = new Vector3(position.x, targetY, position.z);

            ApplyForce(Seek(targetPos, weight));
        }
        else
        {
            Vector3 normalVelocity = velocity.normalized;
            ApplyForce(normalVelocity * -1, weight);
        }

    }


    // update an enemy's position via forces
    protected void ApplyForce(Vector3 force, float weight = 1)
    {
        acceleration += (force * weight) / mass;
    }

    
    // Start is called before the first frame update
    protected override void Start()
    {
        position.x = 9;
        target = enemyManager.collisionManager.player;

        // Random starting y position
        position.y = Random.Range(-4, 4);
        
        base.Start();
    }
    
    // Update is called once per frame
    protected override void Update()
    {

        // Update the enemy's position using forces
        velocity += acceleration * Time.deltaTime;
        position += velocity;

        Animate();

        acceleration = Vector3.zero;

        transform.position = position;


        // Take Damage from projectiles
        if (isHit)
        {
            health -= 1;
            isHit = false;
        }

        if (health <= 0 || position.x < -10)
        {
            enemyManager.collisionManager.enemies.Remove(gameObject);

            Destroy(gameObject);
        }

        base.Update();
    }
    
}
