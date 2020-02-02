﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoStationBehaviour : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject PickUpEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObj = other.gameObject;
        if (gObj.CompareTag("Player"))
        {
            PlayerShootBehaviour psb = gObj.GetComponentInParent<PlayerShootBehaviour>();
            if (psb != null)
            {
                Instantiate(PickUpEffect, transform.position, Quaternion.identity);
                psb.BulletPrefab = BulletPrefab;
            }
        }
    }
}
