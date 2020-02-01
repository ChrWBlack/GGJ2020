using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorFall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ground")
        {
            Debug.Log("Ground detected");
            Destroy(gameObject);
        }
    }
}
