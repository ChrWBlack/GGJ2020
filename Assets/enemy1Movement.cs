using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Movement : MonoBehaviour
{
    public GameObject bigRobot;
    Vector3 direction;
    Vector3 newDirection;
    Vector3 randPosition;
    float checkDistance;
    float stopTime1;
    float stopTime2;
    float rotationperMinute;
    int move;
    // Start is called before the first frame update
    void Start()
    {
        move = 1;
        randPosition = new Vector3(Random.Range(transform.position.x, bigRobot.transform.position.x), transform.position.y, Random.Range(transform.position.z, bigRobot.transform.position.z));
        rotationperMinute = 100.0f;
        checkDistance = Random.Range(100.0f, 300.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (move == 1)
        {
            movetoAttack();
        }
        if(Vector3.SqrMagnitude(bigRobot.transform.position - transform.position) <= checkDistance)
        {
            fireAttack();
            move = 2;
        }

        Destroy(gameObject, 7.0f);
    }

    void movetoAttack()
    {
        direction = bigRobot.transform.position - transform.position;
        float speed = 5.0f * Time.deltaTime;
        newDirection = Vector3.RotateTowards(transform.forward, direction, speed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.MoveTowards(transform.position, bigRobot.transform.position, speed);
    }

    void fireAttack()
    {
        Debug.Log("ATTACK MOFO");
    }
}

