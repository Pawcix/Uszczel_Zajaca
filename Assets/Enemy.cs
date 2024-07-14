using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Counter counter;

    void Start()
    {
        SetPosition();
    }

    public void AfterClick()
    {
        if (counter.IsGameActive())
        {
            SetPosition();
            gameManager.AddPoint();
        }
    }

    void SetPosition()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(0, 1621), Random.Range(0, 781));
    }
}
