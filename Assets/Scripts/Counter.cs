using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] Text textCounter;

    public GameManager gameManager;

    float counter;
    bool GameIsActive;

    void Start()
    {
        GameIsActive = true;
        counter = 60;
    }

    void Update()
    {
        CheckGameIsActive();
        CountDownTime();
    }

    void CountDownTime()
    {
        if (GameIsActive)
        {
            counter -= Time.deltaTime;
            textCounter.text = "Czas: " + counter.ToString("0");

            gameManager.GetComponent<GameManager>().ShotSoundEffect(0.1f);


            if (counter > 5)
            {
                textCounter.color = Color.black;
            }
            else
            {
                textCounter.color = Color.red;
            }
        }
    }

    public void CheckGameIsActive()
    {
        Cursor.visible = false;

        if (counter > 0)
        {
            Cursor.visible = false;
            GameIsActive = true;
        }
        else
        {
            Cursor.visible = true;
            GameIsActive = false;
        }
    }

    public bool IsGameActive()
    {
        return GameIsActive;
    }

    public float GetCounter()
    {
        return counter;
    }
}
