using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{

    [SerializeField]
    private bool useDeltaTime;
    private float turnAmount = 2 * Mathf.PI / (60 ^ 2);

    private Quaternion totalRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //turnAmount -= 2 * Mathf.PI / (60 ^ 2);

        if (useDeltaTime)
        {
            turnAmount -= 2 * Mathf.PI * Time.deltaTime;

            totalRotation = Quaternion.Euler(0, 0, turnAmount);
            transform.rotation = totalRotation;
        }
        else
        {
            turnAmount -= 2 * Mathf.PI / (60 ^ 2);

            totalRotation = Quaternion.Euler(0, 0, turnAmount);
            transform.rotation = totalRotation;
        }

    }
}
