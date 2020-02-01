using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Movement : MonoBehaviour
{
    public GameObject bigRobot;
    Vector3 direction;
    Vector3 newDirection;
    Vector3 randPosition;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (move == 1)
        {
            movetoAttack();
        }
        else if (move == 2 || transform.position == randPosition)
        {
            fireAttack();
        }
        Destroy(gameObject, 7.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Enemy1(Clone)" || other.gameObject.name == "Enemy(Clone)")
        {
            move = 2;
        }
    }

    void movetoAttack()
    {
        direction = bigRobot.transform.position - transform.position;
        float speed = 5.0f * Time.deltaTime;
        newDirection = Vector3.RotateTowards(transform.forward, direction, speed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.MoveTowards(transform.position, randPosition, speed);
    }

    void fireAttack()
    {
        Debug.Log("ATTACK MOFO");
    }
}

