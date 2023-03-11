using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private LoadSceneManager loadSceneManager;

    private void Awake()
    {
        loadSceneManager = FindObjectOfType<LoadSceneManager>();    
    }

    public void StartGame(string nameScene)
    {
        StartCoroutine(loadSceneManager.SwitchScene(nameScene));
    }
}
