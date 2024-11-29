using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseTracker : MonoBehaviour
{
    private Camera cam;
    private PhysicsObject physicsObject;


    // Method to apply a force toward the cursor
    public Vector3 MousePuller(Vector3 position)
    {
        Vector3 mousePosition = new Vector3(0f,0f,0f);

        mousePosition = Mouse.current.position.ReadValue();
        mousePosition = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0f));

        Vector3 difference = mousePosition - position;

        return difference;
    }


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        physicsObject = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    void Update()
    {
        physicsObject.ApplyForce(MousePuller(physicsObject.Position));
    }
}

//