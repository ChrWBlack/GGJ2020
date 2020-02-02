using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBehaviour : MonoBehaviour
{
    public Transform BottomHalf;
    public float MoveSpeed;
    public GameObject DizzySwirls;
    public float DizzyTime = 1.2f;
    private bool isDizzy = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDizzy)
        {
            return;
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            StartCoroutine(DizzyRoutine());
        }
    }

    IEnumerator DizzyRoutine()
    {
        isDizzy = true;
        DizzySwirls.SetActive(true);
        yield return new WaitForSeconds(DizzyTime);
        isDizzy = false;
        DizzySwirls.SetActive(false);
    }
}
