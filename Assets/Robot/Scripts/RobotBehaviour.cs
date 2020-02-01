using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehaviour : MonoBehaviour, IDamageable
{
    public GameObject HealthBarPrefab;
    public float DamagedThreshold;
    public int MaxHealth;
    public Transform UpperBody;
    private int healthPoints;
    private HealthBarBehaviour healthBar;
    private Animator animator;

    private List<Transform> RangeEnemies = new List<Transform>();
    private List<Transform> MeleeEnemies = new List<Transform>();

    public string GetTag()
    {
        return tag;
    }

    public void ReceiveDamage(int damage)
    {
        healthPoints = Mathf.Clamp(healthPoints - damage, 0, MaxHealth);
        UpdateHealthBar();
        UpdateAnimator();
    }

    public void RestoreHealth(int health)
    {
        healthPoints = Mathf.Clamp(healthPoints + health, 0, MaxHealth);
        UpdateHealthBar();
        UpdateAnimator();
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

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

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
        }
        else
        {
            animator.SetInteger(RobotAnimationConstants.AnimationState, RobotAnimationConstants.AnimIdle);
        }
    }
}
