using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ClockNumbers : MonoBehaviour
{
    [SerializeField]
    private GameObject clockNumber;
    private List<GameObject> clockNumbers = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            float posCalculation = (Mathf.PI * (float)2 * i / 12F)+2*Mathf.PI/3;
            Vector3 position = new Vector3(-Mathf.Cos(posCalculation),Mathf.Sin(posCalculation),0F);
            //GameObject nextNumber = Instantiate(clockNumber, position*2, Quaternion.identity);
            //nextNumber.GetComponent<TextMesh>().text = "test";

            clockNumbers.Add(Instantiate(clockNumber, position * 2, Quaternion.identity));
            clockNumbers[i].GetComponent<TextMesh>().text = (i+1).ToString();

            //clockNumbers.Add(nextNumber);
            //clockNumbers[i].GetComponent<Text>().text = i.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
