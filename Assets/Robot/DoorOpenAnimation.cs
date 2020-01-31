using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenAnimation : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;

    private bool isOpen = false;

    private float targetZ = -0.0172f;
    private float targetXR = 0.0117f;
    private float targetXL = -0.0117f;

    // Update is called once per frame
    void Update()
    {
        if (!isOpen)
        {
            if (transform.localPosition.z < targetZ)
            {
                leftDoor.transform.localPosition -= new Vector3 (0.0f, 0.0f, 0.01f * Time.deltaTime);
                rightDoor.transform.localPosition -= new Vector3 (0.0f, 0.0f, 0.01f * Time.deltaTime);
            }
            else
            {
                rightDoor.transform.localPosition -= new Vector3( 0.01f * Time.deltaTime, 0.0f, 0.0f);
                leftDoor.transform.localPosition += new Vector3( 0.01f * Time.deltaTime, 0.0f, 0.0f);
            }
            

        }
    }
}
