using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRangedEnemyHack : MonoBehaviour
{
    public void ShootingHack()
    {
        transform.parent.GetComponent<enemy1Movement>().PlayShootEffect();
    }
}
