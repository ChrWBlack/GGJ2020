using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cycleFixes : MonoBehaviour
{
    public GameObject[] fixItems;
    public GameObject robotBooty;
    public float leastCycleTime;
    public float maxCycleTime;
    Vector3 bootyPosition;
    //Vector3 bootyRotation;
    float spawnTime;
    public float startTime;
    bool stop;
    // Start is called before the first frame update
    void Start()
    {
        bootyPosition = robotBooty.transform.position;
        //bootyRotation = robotBooty.transform.rotation;
        stop = true;
        StartCoroutine(cycleItems());
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = Random.Range(leastCycleTime, maxCycleTime);
    }

    IEnumerator cycleItems()
    {
        yield return new WaitForSeconds(startTime);
        while(stop)
        {
            int randItem = Random.Range(0, 4);
            Instantiate(fixItems[randItem], bootyPosition, fixItems[randItem].transform.rotation);
            if(randItem == 0)
            {
                GameObject.Find("BigRobot").tag = "Bullet2";
            }
            else if(randItem == 1)
            {
                GameObject.Find("BigRobot").tag = "Bullet4";
            }
            else if(randItem == 2)
            {
                GameObject.Find("BigRobot").tag = "Bullet1";
            }
            else if(randItem == 3)
            {
                GameObject.Find("BigRobot").tag = "Bullet3";
            }
            yield return new WaitForSeconds(spawnTime);
            Destroy(GameObject.Find(fixItems[randItem].name + "(Clone)"));
        }
    }
}
