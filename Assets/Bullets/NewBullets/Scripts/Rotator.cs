using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    public bool rotateX = false;
    public bool rotateY = false;
    public bool rotateZ = false;


    // Update is called once per frame
    void Update()
    {
        if (rotateX)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
        if (rotateY)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (rotateZ)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}
