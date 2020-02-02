using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorFall : MonoBehaviour
{
    public GameObject explosionEffect;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Debug.Log("Ground detected");
        Destroy(gameObject);
    }
}
