﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWeapon : MonoBehaviour
{
    public bool isMelee = true;
    public GameObject bigRobot;
    public bool isActivated = false;
    public GameObject label;
    public GameObject theOtherButton;
    //button is this gameobject

    private float rotationDirection = 1.0f;

    private void Update()
    {
        if (isActivated)
        {
            label.transform.Rotate(Vector3.forward * 100.0f * rotationDirection * Time.deltaTime);
            if (label.transform.rotation.z <= -0.5f || label.transform.rotation.z >= 0.5f)
            {
                rotationDirection *= -1.0f;
            }
            //Debug.Log(label.transform.rotation.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("BulletGeneric"))
        {
            Destroy(other.gameObject);
            if (!isActivated)
            {
                isActivated = true;
                theOtherButton.GetComponent<ActivateWeapon>().SetActivated(!isActivated);
                bigRobot.GetComponent<RobotBehaviour>().ChangeWeapon(isMelee);
            }
        }
    }

    public void SetActivated(bool isActivated)
    {
        this.isActivated = isActivated;
    }

}
