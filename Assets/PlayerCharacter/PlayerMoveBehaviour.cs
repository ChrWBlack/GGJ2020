using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBehaviour : MonoBehaviour
{
    public Transform BottomHalf;
    public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get movement direction
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.z = Input.GetAxis("Vertical");

        if (moveDirection.sqrMagnitude > 0.5f)
        {
            moveDirection.Normalize();

            // Move character
            transform.position += moveDirection * Time.deltaTime * MoveSpeed;

            // Rotate bottom half of character
            float rotationAngle = Vector3.SignedAngle(BottomHalf.forward, moveDirection, BottomHalf.up);
            BottomHalf.Rotate(BottomHalf.up, rotationAngle);
        }
    }
}
