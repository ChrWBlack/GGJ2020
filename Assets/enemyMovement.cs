using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public GameObject bigRobot;
    Vector3 direction;
    Vector3 newDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * 5.0f);
        direction = bigRobot.transform.position - transform.position;
        float speed = 5.0f * Time.deltaTime;
        newDirection = Vector3.RotateTowards(transform.forward, direction, speed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.MoveTowards(transform.position, bigRobot.transform.position, speed);
        Destroy(gameObject, 7.0f);
    }
}
