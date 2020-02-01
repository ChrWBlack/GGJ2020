using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehaviour : MonoBehaviour, IDamageable
{
    public GameObject HealthBarPrefab;
    public GameObject ProjectilePrefab;
    public Collider MeleeCollider;
    public float DamagedThreshold;
    public int MaxHealth;
    public Transform UpperBody;
    public Transform ProjectileSpawn;
    public float SecBetweenAttacks;
    private int healthPoints;
    private HealthBarBehaviour healthBar;
    private Animator animator;
    private float SecToNextAttack = 0.0f;

    // true = melee, false = range
    private bool attackModeMelee = true;
    private bool enemydetected = false;

    private List<Transform> rangeEnemies = new List<Transform>();
    private List<Transform> meleeEnemies = new List<Transform>();

    public string GetTag()
    {
        return tag;
    }

    public void ReceiveDamage(int damage)
    {
        healthPoints = Mathf.Clamp(healthPoints - damage, 0, MaxHealth);
        UpdateHealthBar();
    }

    public void RestoreHealth(int health)
    {
        healthPoints = Mathf.Clamp(healthPoints + health, 0, MaxHealth);
        UpdateHealthBar();
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar = Instantiate(HealthBarPrefab).GetComponent<HealthBarBehaviour>();
        Vector3 healthbarPosition = transform.position;
        healthbarPosition.y = 10.5f;
        healthBar.transform.position = healthbarPosition;
        healthPoints = MaxHealth;
        healthBar.AngleToCamera();
        UpdateHealthBar();

        SecToNextAttack = SecBetweenAttacks;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SecToNextAttack > 0.0f)
        {
            SecToNextAttack -= Time.deltaTime;
        }
        meleeEnemies.RemoveAll(item => item == null);
        rangeEnemies.RemoveAll(item => item == null);
        Vector3 targetDirection = Vector3.zero;
        if (attackModeMelee && meleeEnemies.Count > 0)
        {
            targetDirection = meleeEnemies[0].position - transform.position;
            targetDirection.y = 0;
            enemydetected = true;
        }
        else if (!attackModeMelee && rangeEnemies.Count > 0)
        {
            targetDirection = rangeEnemies[0].position - transform.position;
            targetDirection.y = 0;
            enemydetected = true;
        }

        targetDirection.Normalize();

        // Rotate top half of character
        float rotationAngle = Vector3.SignedAngle(transform.forward, targetDirection, transform.up);
        transform.Rotate(transform.up, rotationAngle);

        UpdateAnimator();
    }

    void UpdateHealthBar()
    {
        healthBar.SetValue(healthPoints, MaxHealth); ;
    }

    void UpdateAnimator()
    {
        if (healthPoints < MaxHealth * DamagedThreshold)
        {
            animator.SetInteger(RobotAnimationConstants.AnimationState, RobotAnimationConstants.AnimDamaged);
            MeleeCollider.enabled = false;
        }
        else
        {
            MeleeCollider.enabled = true;
            if (SecToNextAttack <= 0.0f && enemydetected)
            {
                animator.SetTrigger(attackModeMelee ? RobotAnimationConstants.AnimDrill : RobotAnimationConstants.AnimShoot);
                SecToNextAttack += SecBetweenAttacks;
                enemydetected = false;
            }
            else
            {
                animator.SetInteger(RobotAnimationConstants.AnimationState, RobotAnimationConstants.AnimIdle);
            }
        }
    }

    public void SpawnProjectile()
    {
        GameObject projectile = Instantiate(ProjectilePrefab, ProjectileSpawn.position, transform.rotation);
        if (rangeEnemies.Count > 0)
        {
            projectile.transform.LookAt(rangeEnemies[0].position + Vector3.up * 3);
        }
    }

    public void ChangeWeapon(bool isMelee)
    {
        attackModeMelee = isMelee;
        MeleeCollider.enabled = attackModeMelee;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RangeEnemy"))
        {
            rangeEnemies.Add(other.transform);
            other.GetComponentInParent<enemy1Movement>().SetTargetDamageable(this);
        }
        else if (other.CompareTag("MeleeEnemy"))
        {
            meleeEnemies.Add(other.transform);
            other.GetComponentInParent<enemyMovement>().SetTargetDamageable(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RangeEnemy"))
        {
            rangeEnemies.Remove(other.transform);
        }
        else if (other.CompareTag("MeleeEnemy"))
        {
            meleeEnemies.Remove(other.transform);
        }
    }
}
