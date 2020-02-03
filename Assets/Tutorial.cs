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
    public GameObject pressSpaceText;

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

    private string[] messages = new string[7];
    private bool inputAccepted = true;
    private int currentMessage = 0;

    public void NewMessage(int tutLevel)
    {
        newMessage = true;
        switch (tutLevel)
        {
            case 0:
                Level0(currentMessage);
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

    private void Level0(int messageIndex)
    {
        tutText.text = messages[messageIndex];
        //StartCoroutine(TutWait0(3.0f));
        if (messageIndex == 0)
        {
            spotlight.SetActive(true);
            spotlight1.SetActive(true);
            spotlight2.SetActive(true);
            spotlight3.SetActive(true);
        }
        
        if (messageIndex == 2)
        {
            Instantiate(smokeSmall, bulletSpawn.transform.position, Quaternion.identity);
            bulletSpawn.SetActive(true);
            Instantiate(smokeSmall, bulletSpawn1.transform.position, Quaternion.identity);
            bulletSpawn1.SetActive(true);
            Instantiate(smokeSmall, bulletSpawn2.transform.position, Quaternion.identity);
            bulletSpawn2.SetActive(true);
            Instantiate(smokeSmall, bulletSpawn3.transform.position, Quaternion.identity);
            bulletSpawn3.SetActive(true);
        }
        if (messageIndex == 6)
        {
            inputAccepted = false;
            pressSpaceText.SetActive(false);
        }
    }

    private void Level1()
    {
        inputAccepted = false;
        pressSpaceText.SetActive(false);
        tutText.text = "choose one oF the weapons.";
        Instantiate(smokeBig, button1.transform.position, Quaternion.identity);
        button1.SetActive(true);
        Instantiate(smokeBig, button2.transform.position, Quaternion.identity);
        button2.SetActive(true);
    }

    private void Level2()
    {
        tutText.text = "enemies will now spawn!";
        enemySpawner.SetActive(true);
        TutorialFinished.Invoke();
        StartCoroutine(TutorialEndMessage());
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

        messages[0] = "use the correct ammo to heal robo";
        messages[1] = "There are Four types of ammo you can use.";
        messages[2] = "Walk over them to switch between ammo types.";
        messages[3] = "Use the arrow keys to aim and Fire.";
        messages[4] = "Hitting ROBO with the wrong ammo type will damage him instead!";
        messages[5] = "Robo will only atack when above 80% HP.";
        messages[6] = "Try and heal ROBO.";

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

        if (Input.GetKeyDown(KeyCode.Space) && inputAccepted)
        {
            currentMessage++;
            Level0(currentMessage);
        }
    }

    private IEnumerator TutWait0(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        tutText.text = "There are Four types of ammo you can use.";
        Instantiate(smokeSmall, bulletSpawn.transform.position, Quaternion.identity);
        bulletSpawn.SetActive(true);
        Instantiate(smokeSmall, bulletSpawn1.transform.position, Quaternion.identity);
        bulletSpawn1.SetActive(true);
        Instantiate(smokeSmall, bulletSpawn2.transform.position, Quaternion.identity);
        bulletSpawn2.SetActive(true);
        Instantiate(smokeSmall, bulletSpawn3.transform.position, Quaternion.identity);
        bulletSpawn3.SetActive(true);
        yield return new WaitForSeconds(seconds);
        tutText.text = "Walk over them to switch between ammo types.";
        yield return new WaitForSeconds(seconds);
        tutText.text = "Use the arrow keys to aim and Fire.";
        yield return new WaitForSeconds(seconds);
        tutText.text = "Hitting ROBO with the wrong ammo type will damage him instead!";
        yield return new WaitForSeconds(seconds);
        tutText.text = "Robo will only atack when above 80% HP.";
        yield return new WaitForSeconds(seconds);
        tutText.text = "Try and heal ROBO.";
    }

    private IEnumerator TutorialEndMessage()
    {
        yield return new WaitForSeconds(2.5f);
        tutText.text = "Good Luck!";
        yield return new WaitForSeconds(1.0f);
        ClearMessage();
    }
}
