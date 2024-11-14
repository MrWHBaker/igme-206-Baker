using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    // ======== FIELDS =============================================================================
    
    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;

    [SerializeField]
    private float mass;

    // External force detail
    [SerializeField]
    private bool hasFriction = false;
    [SerializeField]
    private float frictionCoeff;

    [SerializeField]
    private bool hasGravity;
    private float gravityStrength;

    private float maxSpeed;


    MouseTracker mouseTracker;


    // ======== Force application methods ==========================================================

    // Method to apply the force of friction to an object


    // Method to apply the force of gravty to an object


    // OPTIONAL apply rotation
    

    // Method to bounce off window edges


    // ======== Standard behavior ================================================================
    // Start is called before the first frame update
    void Start()
    {
        mouseTracker = GetComponent<MouseTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
