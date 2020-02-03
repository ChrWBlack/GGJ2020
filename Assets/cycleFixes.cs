using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cycleFixes : MonoBehaviour
{
    public GameObject[] fixItems;
    public GameObject daRobot;
    public float leastCycleTime;
    public float maxCycleTime;

    public GameObject smileyFaceEffect;

    //Vector3 bootyRotation;
    float spawnTime;
    public float startTime;
    public bool stop = true;
    GameObject currentDisplay;
    // Start is called before the first frame update
    void Start()
    {
        //bootyRotation = robotBooty.transform.rotation;
        stop = true;
        StartCoroutine(newItem());
    }

    public void ChangeDisplay()
    {
        
        StopAllCoroutines();
        daRobot.GetComponent<RobotBehaviour>().SetUntachable(true);
        stop = true;
        Destroy(currentDisplay);
        Instantiate(smileyFaceEffect, transform.position, Quaternion.identity);
        StartCoroutine(newItem());
    }

    public void IncreaseDisplaySize()
    {
        currentDisplay.transform.localScale += new Vector3 (0.05f, 0.05f, 0.05f);
    }

    IEnumerator newItem()
    {
        yield return new WaitForSeconds(startTime);
        while(stop)
        {
            int randItem = Random.Range(0, 4);
            currentDisplay = Instantiate(fixItems[randItem], transform.position, fixItems[randItem].transform.rotation);
            currentDisplay.transform.parent = transform;

            Vector3 targetScale = currentDisplay.transform.localScale;
            float timer = 0.0f;
            currentDisplay.transform.localScale = Vector3.zero;
            while (currentDisplay.transform.localScale.x < targetScale.x  - float.Epsilon)
            {
                currentDisplay.transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, timer * 0.5f);
                yield return new WaitForEndOfFrame();
                timer += Time.deltaTime;
            }

            daRobot.GetComponent<RobotBehaviour>().SetUntachable(false);
            if (randItem == 0)
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
            stop = false;
            //spawnTime = Random.Range(leastCycleTime, maxCycleTime);
            //yield return new WaitForSeconds(spawnTime);
            //
            //daRobot.GetComponent<RobotBehaviour>().SetUntachable(true);
            //Vector3 startScale = currentDisplay.transform.localScale;
            //timer = 0.0f;
            //while (currentDisplay.transform.localScale.x > float.Epsilon)
            //{
            //    currentDisplay.transform.localScale = Vector3.Lerp(startScale, Vector3.zero, timer * 1.5f);
            //    yield return new WaitForEndOfFrame();
            //    timer += Time.deltaTime;
            //}
            //Destroy(currentDisplay);
        }
    }
}
