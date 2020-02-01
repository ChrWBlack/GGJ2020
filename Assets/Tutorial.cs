using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject enemySpawner;
    public GameObject bigRobot;
    public GameObject button1;
    public GameObject button2;

    public Image robotIcon;
    public CanvasGroup textGroup;
    public Text tutText;

    public GameObject spotlight;
    public GameObject spotlight1;
    public GameObject spotlight2;
    public GameObject spotlight3;

    public GameObject bulletSpawn;
    public GameObject bulletSpawn1;
    public GameObject bulletSpawn2;
    public GameObject bulletSpawn3;

    public GameObject smokeSmall;
    public GameObject smokeBig;

    public event Action TutorialFinished;

    public bool newMessage;

    public void NewMessage(int tutLevel)
    {
        newMessage = true;
        switch (tutLevel)
        {
            case 0:
                Level0();
                break;
            case 1:
                Level1();
                break;
            case 2:
                Level2();
                break;
        }
    }

    public void ClearMessage()
    {
        newMessage = false;
        StopAllCoroutines();
    }

    private void Level0()
    {
        tutText.text = "use the correct ammo to heal robo";
        StartCoroutine(TutWait0(6.0f));
        spotlight.SetActive(true);
        spotlight1.SetActive(true);
        spotlight2.SetActive(true);
        spotlight3.SetActive(true);
    }

    private void Level1()
    {
        tutText.text = "use any bullet to swap between melee and ranged weapons";
        Instantiate(smokeBig, button1.transform.position, Quaternion.identity);
        button1.SetActive(true);
        Instantiate(smokeBig, button2.transform.position, Quaternion.identity);
        button2.SetActive(true);
    }

    private void Level2()
    {
        tutText.text = "enemies will now spawn. Robo will atack when above 80% HP";
        enemySpawner.SetActive(true);
        TutorialFinished.Invoke();
        ClearMessage();
    }

    private void Start()
    {
        enemySpawner.SetActive(false);

        button1.SetActive(false);
        button2.SetActive(false);

        spotlight.SetActive(false);
        spotlight1.SetActive(false);
        spotlight2.SetActive(false);
        spotlight3.SetActive(false);
        
        bulletSpawn.SetActive(false);
        bulletSpawn1.SetActive(false);
        bulletSpawn2.SetActive(false);
        bulletSpawn3.SetActive(false);
        NewMessage(0);
    }

    void Update()
    {
        if (newMessage)
        {
            if (textGroup.alpha < 1.0f)
                textGroup.alpha += 2f * Time.deltaTime;
        }
        else
        {
            if (textGroup.alpha > 0.0f)
                textGroup.alpha += -2f * Time.deltaTime;
        }
    }

    private IEnumerator TutWait0(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        tutText.text = "using incorect ammo will damage robo";
        Instantiate(smokeSmall, bulletSpawn.transform.position, Quaternion.identity);
        bulletSpawn.SetActive(true);
        Instantiate(smokeSmall, bulletSpawn1.transform.position, Quaternion.identity);
        bulletSpawn1.SetActive(true);
        Instantiate(smokeSmall, bulletSpawn2.transform.position, Quaternion.identity);
        bulletSpawn2.SetActive(true);
        Instantiate(smokeSmall, bulletSpawn3.transform.position, Quaternion.identity);
        bulletSpawn3.SetActive(true);
    }
}
