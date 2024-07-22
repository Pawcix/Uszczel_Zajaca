using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] Text textPoint;
    [SerializeField] Counter counter;
    [SerializeField] Image imgViewFinder;
    [SerializeField] AudioClip shotSound;

    int points;
    bool playedShotSound;

    void Start()
    {
        points = 0;
        playedShotSound = false;
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

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShotSoundEffect(float volume)
    {
        if (Input.GetMouseButtonDown(0) && !playedShotSound)
        {
            AudioSource.PlayClipAtPoint(shotSound, transform.position, volume);
            playedShotSound = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            playedShotSound = false;
        }
    }
}
