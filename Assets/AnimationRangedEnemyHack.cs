using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRangedEnemyHack : MonoBehaviour
{
    public AudioSource clip;
    public void ShootingHack()
    {
        clip.Play();
        transform.parent.GetComponent<enemy1Movement>().PlayShootEffect();
    }
}
