using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyInstantiate : MonoBehaviour
{
    public GameObject enemyPrefab;
    int maxWaittime;
    int modifier;
    // Start is called before the first frame update
    void Start()
    {
        maxWaittime = 700;
    }

    // Update is called once per frame
    void Update()
    {
        modifier = Random.Range(0, maxWaittime);
        //Debug.Log(modifier);
        if (modifier == maxWaittime - 1)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            Debug.Log("Enemy spawned");
        }
    }
}
