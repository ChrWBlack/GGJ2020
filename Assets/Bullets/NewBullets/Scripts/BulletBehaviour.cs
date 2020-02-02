using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float Speed = 30.0f;
    public string HealTag;
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            if (damageable.GetTag().Equals(HealTag))
            {
                damageable.RestoreHealth(1);
                
            }
            else
            {
                damageable.ReceiveDamage(1);
            }
        }
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
