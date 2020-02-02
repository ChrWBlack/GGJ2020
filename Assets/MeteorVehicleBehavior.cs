using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorVehicleBehavior : MonoBehaviour
{
    public Transform targetPos;
    public Transform backPos;

    public Transform smokeSpawn;
    public Transform smokeSpawn1;
    public Transform smokeSpawn2;
    public Transform smokeSpawn3;

    public GameObject smoke;
    public AudioSource clip;

    private bool goToTarget;
    private bool goBack;
    private int numberOfShots = 2;
    private Animator anim;

    public GameObject meteorSpawn;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (goToTarget)
        {
            float step = 5.0f * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, step);
            if (Vector3.Distance(transform.position, targetPos.position) < 0.001f)
            {
                goToTarget = false;
                anim.SetTrigger("TriggerCannons");

                SpawnMeteor();
                clip.Play();
                numberOfShots++;
            }
        }

        if (goBack)
        {
            float step = 5.0f * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, backPos.position, step);
            if (Vector3.Distance(transform.position, backPos.position) < 0.001f)
            {
                goBack = false;
            }
        }
    }

    public void TimeForMeteor()
    {
        goToTarget = true;
    }

    public void SmokeEffectBack()
    {
        Instantiate(smoke, smokeSpawn2.position, Quaternion.identity);
        Instantiate(smoke, smokeSpawn3.position, Quaternion.identity);
    }

    public void SmokeEffectFront()
    {
        Instantiate(smoke, smokeSpawn.position, Quaternion.identity);
        Instantiate(smoke, smokeSpawn1.position, Quaternion.identity);
        StopShooting();
    }

    void StopShooting()
    {
        goBack = true;
    }

    void SpawnMeteor()
    {
        //spawn meteor
        if (meteorSpawn != null)
        {
            meteorSpawn.SetActive(true);
        }
    }
}
