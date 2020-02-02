using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour, IDamageable
{
    public Vector3 TargetPosition;
    public Animator Animator;
    public GameObject spawnEffect;
    public GameObject deathEffect;
    Vector3 direction;
    Vector3 newDirection;
    Rigidbody enemyBody;
    int move;

    public float AttacksPerSecond = 2;
    private float SecondsToNextAttack = 0;

    public int MaxHealth = 1;
    private int currentHealth;
    private IDamageable damageableTarget;

    void Awake()
    {
        Instantiate(spawnEffect, transform.position + new Vector3(0.0f, 2.0f, 0.0f), Quaternion.EulerAngles(-90.0f,0.0f,0.0f));
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = gameObject.GetComponent<Rigidbody>();
        //enemyBody.isKinematic = true;
        move = 1;
        currentHealth = MaxHealth;
        SecondsToNextAttack = 1.0f / AttacksPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        if (SecondsToNextAttack > 0)
        {
            SecondsToNextAttack -= Time.deltaTime;
        }
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
        if ((transform.position - TargetPosition).sqrMagnitude < 12)
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
        Animator.SetInteger("AnimationState", 1);
        if (SecondsToNextAttack <= 0 && damageableTarget != null)
        {
            damageableTarget.ReceiveDamage(1);
            SecondsToNextAttack += 1.0f / AttacksPerSecond;
        }
    }

    public void SetTargetDamageable(IDamageable damageable)
    {
        damageableTarget = damageable;
    }

    public void ReceiveDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position + new Vector3(0.0f, 2.0f, 0.0f), Quaternion.EulerAngles(-90.0f, 0.0f, 0.0f));
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
