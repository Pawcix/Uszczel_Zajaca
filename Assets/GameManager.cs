using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text textPoint;
    [SerializeField] Text score;
    [SerializeField] Counter counter;
    [SerializeField] Image imgViewFinder;

    int points;

    void Start()
    {
        points = 0;
        DisplayAmountEnemies();
        ShowScore();
    }

    void Update()
    {
        ShowScore();
    }

    private void LateUpdate()
    {
        imgViewFinder.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
    }

    void ShowScore()
    {
        if(!counter.IsGameActive())
        {
            imgViewFinder.GetComponent<Image>().enabled = false;
            float counterValue = counter.GetCounter();

            score.text = "1. Iloœæ zabitych cweli: " + points;
            score.text += "\n2. Czas gry: " + counterValue.ToString("f2");
        }
    }

    void DisplayAmountEnemies()
    {
        if (counter.IsGameActive())
        {
            textPoint.text = "Iloœæ Zabitych Cweli: " + points;
        }
    }

    public void AddPoint()
    {
        points++;
        DisplayAmountEnemies();
    }
}
