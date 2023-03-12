using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LoadSceneManager : MonoBehaviour
{
    private FadingScreen fadingScreen;
    private void Awake()
    {
        fadingScreen = FindObjectOfType<FadingScreen>();
        StartCoroutine(fadingScreen.Fading());
    }
    
    public IEnumerator SwitchScene(string sceneName)
    {
        yield return StartCoroutine(fadingScreen.Increase());
        gameObject.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
