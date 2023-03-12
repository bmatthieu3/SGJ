using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LoadSceneManager : MonoBehaviour
{
    private static LoadSceneManager instance;
    private FadingScreen fadingScreen;
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

        fadingScreen = FindObjectOfType<FadingScreen>();
    }
    
    public IEnumerator SwitchScene(string sceneName)
    {
        yield return StartCoroutine(fadingScreen.Fading());
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
