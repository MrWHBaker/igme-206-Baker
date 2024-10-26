using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    // Stores the prefab we'll be creating
    [SerializeField]
    private GameObject creaturePrefab;

    // Stores a set of coordinates for the prefabs
    [SerializeField]
    private Vector3 location1;
    [SerializeField]
    private Vector3 location2;
    [SerializeField]
    private Vector3 location3;

    // Orientation for constructor
    Quaternion rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(creaturePrefab, location1, rotation);
        Instantiate(creaturePrefab, location2, rotation);
        Instantiate(creaturePrefab, location3, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
