using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour, IDamageable
{
    public Vector3 TargetPosition;
    Vector3 direction;
    Vector3 newDirection;
    Rigidbody enemyBody;
    int move;

    public int MaxHealth = 1;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = gameObject.GetComponent<Rigidbody>();
        //enemyBody.isKinematic = true;
        move = 1;
        currentHealth = MaxHealth;
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

        //Destroy(gameObject, 7.0f);
        if ((transform.position - TargetPosition).sqrMagnitude < 9)
        {
            move = 2;
        }
    }

    void movetoAttack()
    {
        direction = TargetPosition - transform.position;
        float speed = 20.0f * Time.deltaTime;
        newDirection = Vector3.RotateTowards(transform.forward, direction, speed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed);
        
    }

    void meleeAttack()
    {
        //Debug.Log("ATTACK mofo!!");
    }

    public void ReceiveDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void RestoreHealth(int health)
    {
        currentHealth = Mathf.Clamp(currentHealth + health, health, MaxHealth);

    }

    public string GetTag()
    {
        return tag;
    }
}
