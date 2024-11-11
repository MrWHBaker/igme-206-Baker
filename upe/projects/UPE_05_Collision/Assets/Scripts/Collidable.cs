using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class collidable : MonoBehaviour
{
    // ======== FIELDS ============================================================================
    // Represents a script holding the necessary collision method
    CollisionType collisionType;
    CollisionType aabb;
    CollisionType circle;

    [SerializeField]
    GameObject vehicle;

    [SerializeField]
    List<GameObject> collidables;

    [SerializeField]
    GameObject text;

    

    // Start is called before the first frame update
    void Start()
    {
        aabb = GetComponent<AABBcollision>();
        circle = GetComponent<CircleCollision>();
        collisionType = aabb;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the mouse click to swap the collision type
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (collisionType == aabb) { collisionType = circle; }
            else { collisionType = aabb; }
        }

        text.GetComponent<TextMesh>().text = collisionType.ToString();

        // Run the collision check from the selected script
        collisionType.CheckCollision(vehicle, collidables);

    }
}
