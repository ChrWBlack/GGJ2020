using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void ReceiveDamage(int damage, bool playClip = false);
    void RestoreHealth(int health);
    string GetTag();
}
