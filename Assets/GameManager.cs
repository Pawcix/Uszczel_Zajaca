using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text textPoint;
    [SerializeField] Counter counter;
    [SerializeField] Image imgViewFinder;

    int points;

    void Start()
    {
        points = 0;
        DisplayAmountEnemies();
    }

    void LateUpdate()
    {
        if (counter.IsGameActive())
        {
            imgViewFinder.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
        }
        else
        {
            imgViewFinder.gameObject.SetActive(false);
        }
    }

    void DisplayAmountEnemies()
    {
        if (counter.IsGameActive())
        {
            textPoint.text = "Iloœæ Uszczelonych Zaj¹ców: " + points;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddPoint()
    {
        points++;
        DisplayAmountEnemies();
    }
}
