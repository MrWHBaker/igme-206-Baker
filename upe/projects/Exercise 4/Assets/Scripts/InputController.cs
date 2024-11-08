using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    MovementController myMovementController;

    // The method that gets called to handle any player movement input
    public void OnMove(InputAction.CallbackContext context)
    {

        // Get the latest value for the input from the Input System
        Vector2 inputDirection = context.ReadValue<Vector2>();  // This is already normalized for us

        // Send that new direction to the Vehicle class
        myMovementController.SetDirection(inputDirection);

    }


    // Start is called before the first frame update
    void Start()
    {
        myMovementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
