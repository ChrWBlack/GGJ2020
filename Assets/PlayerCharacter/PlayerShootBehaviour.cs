using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{
    public Transform TopHalf;
    public Transform BulletSpawn;
    public float SecBetweenShots;
    public GameObject BulletPrefab;

    private float SecToNextShot = 0.0f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        SecToNextShot = SecBetweenShots;
        animator = TopHalf.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SecToNextShot > 0.0f)
        {
            SecToNextShot -= Time.deltaTime;
        }

        // Get shooting direction
        Vector3 shootDirection = Vector3.zero;
        shootDirection.x = Input.GetAxis("Horizontal2");
        shootDirection.z = Input.GetAxis("Vertical2");

        if (shootDirection.sqrMagnitude > 0.5f)
        {
            animator.SetInteger(PlayerAnimationConstants.AnimationState, PlayerAnimationConstants.PlayerThrowing);

            shootDirection.Normalize();

            // Rotate top half of character
            float rotationAngle = Vector3.SignedAngle(TopHalf.forward, shootDirection, TopHalf.up);
            TopHalf.Rotate(TopHalf.up, rotationAngle);

            if (SecToNextShot <= 0.0f && BulletPrefab != null)
            {
                Instantiate(BulletPrefab, BulletSpawn.position, TopHalf.rotation);
                SecToNextShot += SecBetweenShots;
            }
        }
        else
        {
            animator.SetInteger(PlayerAnimationConstants.AnimationState, PlayerAnimationConstants.PlayerRunning);
        }
    }
}
