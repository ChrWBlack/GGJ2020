using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Vector3 spawnValues;
    float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public float startWait;
    bool stop;
    Vector3 spawnPosition;
    int randEnemy;

    int numberOfEnemiesSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        stop = true;
        StartCoroutine(enemyBirthing());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator enemyBirthing()
    {
        yield return new WaitForSeconds(startWait);

        while(stop)
        {
            randEnemy = Random.Range(0, enemyPrefab.Length);
            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(enemyPrefab[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            ++numberOfEnemiesSpawned;
            if(numberOfEnemiesSpawned%10 == 0)
            {
                if (spawnLeastWait > 0.05f)
                    spawnLeastWait -= 0.05f;
                if (spawnMostWait > 1.0f)
                    spawnMostWait -= 0.05f;
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
