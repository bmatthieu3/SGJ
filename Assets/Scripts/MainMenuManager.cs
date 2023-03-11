using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainMenuManager : MonoBehaviour
{
    private LoadSceneManager loadSceneManager;

    [SerializeField] GameObject firstMenu;
    [SerializeField] GameObject creditMenu;

    private void Awake()
    {
        loadSceneManager = FindObjectOfType<LoadSceneManager>();    
    }

    public void StartGame(string nameScene)
    {
        StartCoroutine(loadSceneManager.SwitchScene(nameScene));   
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void GoToCredit()
    {
        creditMenu.SetActive(true);
        firstMenu.SetActive(false);
    }

    public void GoToFirstMenu()
    {
        firstMenu.SetActive(true);
        creditMenu.SetActive(false);
    }
}
