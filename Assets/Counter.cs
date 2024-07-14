using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] Text textCounter;

    float counter;
    bool GameIsActive;

    void Start()
    {
        GameIsActive = true;
        counter = 3;
    }

    void Update()
    {
        CheckGameIsActive();
        CountDownTime();
    }

    void CountDownTime()
    {
        if(GameIsActive)
        {
            counter -= Time.deltaTime;
            textCounter.text = counter.ToString("f2");

            if (counter <= 0)
            {
                textCounter.color = Color.red;
            }
            else
            {
                textCounter.color = Color.white;
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
