using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CollisionManager : MonoBehaviour
{
    // ======== FIELDS ============================================================================
    

    [SerializeField]
    public GameObject player;

    [SerializeField]
    public List<GameObject> projectilesEnemy;
    [SerializeField]
    public List<GameObject> projectilesPlayer;
    [SerializeField]
    public List<GameObject> enemies;


    // ======== METHODS ===========================================================================

    // AABB collision method
    // Calls for the object whose collisions are to be checked, and a list of relevant colliders
    public void CheckCollision(GameObject target, List<GameObject> collidables)
    {
        // Track whether the target has made a collision
        bool colliding = false;

        // Get vehicle's edges and spriteRenderer
        CollidableObject targetHitbox = target.GetComponent<CollidableObject>();
        SpriteRenderer targetSprite = target.GetComponent<SpriteRenderer>();
        float targetMinX = target.transform.position.x - (targetHitbox.MinX);
        float targetMaxX = target.transform.position.x + (targetHitbox.MaxX);
        float targetMinY = target.transform.position.y - (targetHitbox.MinY);
        float targeteMaxY = target.transform.position.y + (targetHitbox.MaxY);

        foreach (GameObject collidable in collidables)
        {
            // Get collidable's edges and spriteRenderer
            CollidableObject collidableHitbox = collidable.GetComponent<CollidableObject>();
            SpriteRenderer collidableSprite = collidable.GetComponent<SpriteRenderer>();
            float collidableMinX = collidable.transform.position.x - (collidableHitbox.MinX);
            float collidableMaxX = collidable.transform.position.x + (collidableHitbox.MaxX);
            float collidableMinY = collidable.transform.position.y - (collidableHitbox.MinY);
            float collidableMaxY = collidable.transform.position.y + (collidableHitbox.MaxY);

            // test AABB overlaps and color the sprite
            if
                (
                targetMinX < collidableMaxX &
                targetMaxX > collidableMinX &
                targetMinY < collidableMaxY &
                targeteMaxY > collidableMinY
                )
            {
                colliding = true;
                collidableHitbox.isHit = true;
            }
        }

        // Update vehicle sprite color
        if (colliding)
        {
            targetHitbox.isHit = true;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach (GameObject projectile in projectilesEnemy)
        {

        }

        // Run the collision check between the player and enemies
        CheckCollision(player, enemies);

        // Run the collision check between the player and enemy projectiles
        CheckCollision(player, projectilesEnemy);

        // Run the collision check between all player projectiles and enemies
        foreach (GameObject enemy in enemies)
        {
            CheckCollision(enemy, projectilesPlayer);
        }


    }
}
