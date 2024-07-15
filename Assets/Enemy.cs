using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioClip deathSound;
    [SerializeField] Counter counter;

    void Start()
    {
        SetPosition();
    }

    void SetPosition()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(0, 1621), Random.Range(0, 681));
    }

    void DeathSound()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

    public void AfterClick()
    {
        if (counter.IsGameActive())
        {
            SetPosition();
            DeathSound();
            gameManager.AddPoint();
        }
    }
}
