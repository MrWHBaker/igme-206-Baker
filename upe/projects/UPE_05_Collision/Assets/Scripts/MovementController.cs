using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementController : MonoBehaviour
{
    // ======== Class fields ======================================================================
    // Where is the vehicle
    Vector3 objectPosition = new Vector3(0, 0, 0);

    // How fast it should move in units per second
    float speed = 4f;

    // Direction vehicle is facing, must be normalized
    Vector3 direction = new Vector3(1, 0, 0);   // or Vector3.right

    // The delta in position for a single frame
    Vector3 velocity = new Vector3(0, 0, 0);   // or Vector3.zero

    //[SerializeField]
    Vector2 windowSize = new Vector2(16,10);


    // Method to recieve a direction vector from InputController
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }


    // Start is called before the first frame update
    void Start()
    {
        // Grab the GameObject’s starting position
        objectPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Velocity is direction * speed * deltaTime
        velocity = direction * speed * Time.deltaTime;

        // Add velocity to position 
        objectPosition += velocity;

        // Validate new calculated position
        if (Mathf.Abs(objectPosition.x) > windowSize.x/2)
        {
            objectPosition.x = -objectPosition.x;
        }
        if (Mathf.Abs(objectPosition.y) > windowSize.y / 2)
        {
            objectPosition.y = -objectPosition.y;
        }

        // “Draw” this vehicle at that position
        transform.position = objectPosition;


        // Set the vehicle’s rotation to match the direction
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction); // for 2D rotation
        }


    }

}
