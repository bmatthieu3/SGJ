using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuManager : MonoBehaviour
{
    private LoadSceneManager loadSceneManager;
    private SoundManager soundManager;

    [SerializeField] GameObject firstMenu;
    [SerializeField] GameObject creditMenu;

    private void Awake()
    {
        loadSceneManager = FindObjectOfType<LoadSceneManager>();
        soundManager = FindObjectOfType<SoundManager>();

        soundManager.SetMusicMenuOrScore();
    }

    public void StartGame(string nameScene)
    {
        soundManager.PlaySoundButton();
        StartCoroutine(loadSceneManager.SwitchScene(nameScene));   
    }

    public void ButtonQuitGame()
    {
        soundManager.PlaySoundButton();
        loadSceneManager.QuitGame();
    }

    public void GoToCredit()
    {
        soundManager.PlaySoundButton();
        creditMenu.SetActive(true);
        firstMenu.SetActive(false);
    }

    public void GoToFirstMenu()
    {
        soundManager.PlaySoundButton();
        firstMenu.SetActive(true);
        creditMenu.SetActive(false);
    }

}
