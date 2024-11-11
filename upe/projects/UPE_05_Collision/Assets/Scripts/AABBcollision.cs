using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBcollision : CollisionType
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string ToString()
    {
        return "Left click to change mode\nCollision Mode: AABB";
    }

    // AABB collision method
    public override void CheckCollision(GameObject vehicle, List<GameObject> collidables)
    {
        // Get vehicle's edges and spriteRenderer
        SpriteRenderer vehicleSprite = vehicle.GetComponent<SpriteRenderer>();
        float vehicleMinX = vehicle.transform.position.x - (vehicleSprite.size.x) / 2;
        float vehicleMaxX = vehicle.transform.position.x + (vehicleSprite.size.x) / 2;
        float vehicleMinY = vehicle.transform.position.y - (vehicleSprite.size.y) / 2;
        float vehicleMaxY = vehicle.transform.position.y + (vehicleSprite.size.y) / 2;

        // Track whether the vehicle has made a collision
        bool colliding = false;

        foreach (GameObject collidable in collidables)
        {
            // Get collidable's edges and spriteRenderer
            SpriteRenderer collidableSprite = collidable.GetComponent<SpriteRenderer>();
            float collidableMinX = collidable.transform.position.x - (collidableSprite.size.x) / 2;
            float collidableMaxX = collidable.transform.position.x + (collidableSprite.size.x) / 2;
            float collidableMinY = collidable.transform.position.y - (collidableSprite.size.y) / 2;
            float collidableMaxY = collidable.transform.position.y + (collidableSprite.size.y) / 2;

            // test AABB overlaps and color the sprite
            if 
                (
                vehicleMinX < collidableMaxX &
                vehicleMaxX > collidableMinX &
                vehicleMinY < collidableMaxY &
                vehicleMaxY > collidableMinY
                )
            {
                colliding = true;
                collidableSprite.color = Color.red;
            }
            else
            {
                collidableSprite.color = Color.white;
            }
        }

        // Update vehicle sprite color
        if (colliding)
        {
            vehicleSprite.color = Color.red;
        }
        else
        {
            vehicleSprite.color = Color.white;
        }
    }
}
