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
    float speed = 6f;

    // Direction vehicle is facing, must be normalized
    Vector3 direction = new Vector3(0, 0, 0);   // or Vector3.right

    // The delta in position for a single frame
    Vector3 velocity = new Vector3(0, 0, 0);   // or Vector3.zero

    //[SerializeField]
    Vector2 windowSize = new Vector2(16, 10);

    // Prepare to access sprite renderer
    SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite upSprite;
    [SerializeField]
    private Sprite downSprite;
    [SerializeField]
    private Sprite neutralSprite;


    // Method to recieve a direction vector from InputController
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }


    // Start is called before the first frame update
    void Start()
    {
        // Grab the GameObjects starting position
        objectPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Velocity is direction * speed * deltaTime
        velocity = direction * speed * Time.deltaTime;

        // Add velocity to position 
        objectPosition += velocity;

        // Collide with screen edges
        if (Mathf.Abs(objectPosition.x) > windowSize.x / 2)
        {
            objectPosition.x = Mathf.Sign(objectPosition.x)*windowSize.x/2;
            velocity.x = 0;
        }
        if (Mathf.Abs(objectPosition.y) > windowSize.y / 2)
        {
            objectPosition.y = Mathf.Sign(objectPosition.y) * windowSize.y / 2;
            velocity.y = 0;
        }

        // Draw this vehicle at that position
        transform.position = objectPosition;



        // Animate sprite
        if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -10);
        }
        else if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 10);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        
        if (direction.y > 0)
        {
            spriteRenderer.sprite = upSprite;
        }
        else if (direction.y < 0)
        {
            spriteRenderer.sprite = downSprite;
        }
        else
        {
            spriteRenderer.sprite = neutralSprite;
        }
        
    }

}
