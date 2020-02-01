using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public GameObject bigRobot;
    Vector3 direction;
    Vector3 newDirection;
    Rigidbody enemyBody;
    int move;
    bool manners;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = gameObject.GetComponent<Rigidbody>();
        //enemyBody.isKinematic = true;
        move = 1;
        manners = true;
        height = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * 5.0f);
        if(move == 1)
        {
            movetoAttack();
        }
        else if(move == 2)
        {
            meleeAttack();
        }
        else if(move == 3)
        {
            doNothing();
            //manners = true;
            //move = 1;
        }
        Destroy(gameObject, 7.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Enemy(Clone)" || other.gameObject.name == "Enemy1(Clone)")
        {
            if(move != 2)
            {
                move = 1;
            }
        }
        if (other.gameObject.name == "BigRobot")
        {
            move = 2;
        }
        //Debug.Log(other.gameObject.name);
        
    }

    void movetoAttack()
    {
        direction = bigRobot.transform.position - transform.position;
        float speed = 5.0f * Time.deltaTime;
        newDirection = Vector3.RotateTowards(transform.forward, direction, speed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.MoveTowards(transform.position, bigRobot.transform.position, speed);
        
    }

    void meleeAttack()
    {
        Debug.Log("ATTACK mofo!!");
    }

    void doNothing()
    {

    }
}
