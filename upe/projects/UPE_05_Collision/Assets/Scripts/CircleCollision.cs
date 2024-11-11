using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CircleCollision : CollisionType
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
        return "Left click to change mode\nCollision Mode: Circle";
    }

    // Circle collision method
    public override void CheckCollision(GameObject vehicle, List<GameObject> collidables)
    {
        // Get vehicle position and sprite renderer
        Vector3 vehiclePosition = vehicle.transform.position;
        SpriteRenderer vehicleSprite = vehicle.GetComponent<SpriteRenderer>();

        // Track whether the vehicle has made a collision
        bool colliding = false;

        foreach (GameObject collidable in collidables)
        {
            // Get each parked car's position and sprite renderer
            Vector3 collidablePosition = collidable.transform.position;
            SpriteRenderer collidableSprite = collidable.GetComponent<SpriteRenderer>();

            // Measure distance
            float distance = 
                (
                Mathf.Pow((vehiclePosition.x - collidablePosition.x),2) + 
                Mathf.Pow((vehiclePosition.y - collidablePosition.y),2)
                );

            // Update sprite color
            if (distance < 1)
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
