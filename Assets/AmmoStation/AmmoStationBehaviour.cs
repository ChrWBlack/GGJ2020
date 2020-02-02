using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoStationBehaviour : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject PickUpEffect;
    public AudioSource aSource;
    public AudioClip aClip;
    public AudioClip aClip2;

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObj = other.gameObject;
        if (gObj.CompareTag("Player"))
        {
            PlayerShootBehaviour psb = gObj.GetComponentInParent<PlayerShootBehaviour>();
            if (psb != null)
            {
                aSource.PlayOneShot(aClip, 0.05f);
                aSource.PlayOneShot(aClip2, 0.1f);

                Instantiate(PickUpEffect, transform.position, Quaternion.identity);
                psb.BulletPrefab = BulletPrefab;
            }
        }
    }
}
