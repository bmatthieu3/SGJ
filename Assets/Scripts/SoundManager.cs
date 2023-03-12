using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    private AudioSource audioSource;

    [SerializeField] private AudioClip musicMenuScore;
    [SerializeField] private AudioClip musicGame;

    [SerializeField] private AudioSource buttonPopGrave;
    [SerializeField] private AudioSource buttonPopAigu;
    [SerializeField] private AudioSource soundClic;
    [SerializeField] private AudioSource soundWin;
    [SerializeField] private AudioSource soundFail;


    private void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(instance);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

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


    public void PlaySoundButton()
    {
        //int rand = Random.Range(0, 2);

        //if (rand == 0)
        //{
        //    buttonPopAigu.Play();
        //}
        //else
        //{
        //    buttonPopGrave.Play();
        //}

        buttonPopAigu.Play();
    }

    public void PlaySoundClic()
    {
        soundClic.Play();
    }

    public void PlayWin()
    {
        soundWin.Play();
    }

    public void PlayFail()
    {
        soundFail.Play();
    }

   public void PlaySoundCompteur()
    {
        buttonPopGrave.Play();
    }

    public void StopMainSource()
    {
        audioSource.Stop();
    }


}
