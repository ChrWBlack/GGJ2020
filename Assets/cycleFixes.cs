using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cycleFixes : MonoBehaviour
{
    public GameObject[] fixItems;
    public GameObject daRobot;
    public float leastCycleTime;
    public float maxCycleTime;
    //Vector3 bootyRotation;
    float spawnTime;
    public float startTime;
    bool stop;
    GameObject currentDisplay;
    // Start is called before the first frame update
    void Start()
    {
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
            currentDisplay = Instantiate(fixItems[randItem], transform.position, fixItems[randItem].transform.rotation);
            currentDisplay.transform.parent = transform;
            if(randItem == 0)
            {
                daRobot.tag = "Bullet2";
            }
            else if(randItem == 1)
            {
                daRobot.tag = "Bullet4";
            }
            else if(randItem == 2)
            {
                daRobot.tag = "Bullet1";
            }
            else if(randItem == 3)
            {
                daRobot.tag = "Bullet3";
            }
            yield return new WaitForSeconds(spawnTime);
            Destroy(currentDisplay);
        }
    }
}
