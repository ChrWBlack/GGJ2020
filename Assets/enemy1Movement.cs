using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Movement : MonoBehaviour, IDamageable
{
    public Vector3 TargetPosition;
    Vector3 direction;
    Vector3 newDirection;
    Vector3 randPosition;
    float checkDistance;
    int move;

    public int MaxHealth = 1;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        move = 1;
        randPosition = new Vector3(Random.Range(transform.position.x, TargetPosition.x), transform.position.y, Random.Range(transform.position.z, TargetPosition.z));
        checkDistance = Random.Range(500.0f, 1600.0f);
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (move == 1)
        {
            movetoAttack();
        }
        if(Vector3.SqrMagnitude(TargetPosition - transform.position) <= checkDistance)
        {
            fireAttack();
            move = 2;
        }

        //Destroy(gameObject, 7.0f);
    }

    void movetoAttack()
    {
        direction = TargetPosition - transform.position;
        float speed = 18.0f * Time.deltaTime;
        newDirection = Vector3.RotateTowards(transform.forward, direction, speed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed);
    }

    void fireAttack()
    {
        Debug.Log("ATTACK MOFO");
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

