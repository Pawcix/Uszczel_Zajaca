using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem deathParticleSystem;
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioClip deathSound;
    [SerializeField] Counter counter;

    void Start()
    {
        SetPosition();
    }

    void SetPosition()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(0, 1621), Random.Range(0, 651));
    }

    void DeathSound()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

    void DeathPartlicleSystem()
    {
        Vector3 newPosition = gameObject.transform.position;
        newPosition.z = 20;

        ParticleSystem actionParticleSystem = Instantiate(deathParticleSystem);
        actionParticleSystem.gameObject.transform.position = newPosition;
        actionParticleSystem.Play();
        Destroy(actionParticleSystem.gameObject, 2f);
    }

    public void AfterClick()
    {
        if (counter.IsGameActive())
        {
            DeathPartlicleSystem();
            
            DeathSound();
            SetPosition();
            gameManager.AddPoint();
        }
    }
}
