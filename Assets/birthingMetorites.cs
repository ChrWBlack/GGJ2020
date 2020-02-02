using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birthingMetorites : MonoBehaviour
{
    public GameObject fallingMeteor;
    public Vector3 spawnValues;
    public float spawnStart;
    public float maxSpawnWait;
    public float minSpawnWait;
    float spawnWait;
    bool stop;
    Vector3 spawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        stop = true;
        StartCoroutine(startFalling());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(minSpawnWait, maxSpawnWait);
    }

    IEnumerator startFalling()
    {
        yield return new WaitForSeconds(spawnStart);
        while(stop)
        {
            spawnPosition = new Vector3(gameObject.transform.position.x + Random.Range(-spawnValues.x, spawnValues.x), gameObject.transform.position.y, gameObject.transform.position.z + Random.Range(-spawnValues.z, spawnValues.x));
            GameObject tempMeteor = Instantiate(fallingMeteor, spawnPosition, fallingMeteor.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
