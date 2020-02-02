using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Movement : MonoBehaviour, IDamageable
{
    public Vector3 TargetPosition;
    public Animator Animator;
    public GameObject spawnEffect;
    public GameObject deathEffect;
    public GameObject shootEffect;
    public AudioClip deathEffectClip;
    public Transform shootEffectPos;
    Vector3 direction;
    Vector3 newDirection;
    Vector3 randPosition;
    float checkDistance;
    int move;

    public float AttacksPerSecond = 2;
    private float SecondsToNextAttack = 0;

    public int MaxHealth = 1;
    private int currentHealth;

    private IDamageable damageableTarget;

    void Awake()
    {
        Instantiate(spawnEffect, transform.position + new Vector3 (0.0f, 2.0f,0.0f), Quaternion.EulerAngles(-90.0f, 0.0f, 0.0f));
    }

    // Start is called before the first frame update
    void Start()
    {
        move = 1;
        randPosition = new Vector3(Random.Range(transform.position.x, TargetPosition.x), transform.position.y, Random.Range(transform.position.z, TargetPosition.z));
        checkDistance = Random.Range(500.0f, 1600.0f);
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

    public void ReceiveDamage(int damage, bool playClip = false)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position + new Vector3(0.0f, 2.0f, 0.0f), Quaternion.EulerAngles(-90.0f, 0.0f, 0.0f));
            effect.AddComponent<AudioSource>().clip = deathEffectClip;
            effect.GetComponent<AudioSource>().Play();
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

    public void PlayShootEffect()
    {
        Instantiate(shootEffect, shootEffectPos.position, Quaternion.identity);
    }
}

