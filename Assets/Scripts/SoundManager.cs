using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    private AudioSource audioSource;

    [SerializeField] private AudioClip musicMenuScore;
    [SerializeField] private AudioClip musicGame;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void SetMusicMenuOrScore()
    {
        audioSource.clip = musicMenuScore;
        audioSource.Play();
    }

    public void SetMusicGame()
    {
        audioSource.clip = musicGame;
        audioSource.Play();
    }


}
