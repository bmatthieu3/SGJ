using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingScreen : MonoBehaviour
{
    private Image screenRend;
    //[SerializeField]private Color colorScreen;
    [SerializeField] private float lerpDuration = 2f;

    private void Awake()
    {
        screenRend = gameObject.GetComponent<Image>();
        //colorScreen = screenRend.color;
    }

    public IEnumerator Fading()
    {
        float timeElapsed = 0;
        var currentColor = screenRend.color;

        while (timeElapsed < lerpDuration)
        {
            var colorScreen = screenRend.color;
            colorScreen.a = Mathf.Lerp(0, 1, timeElapsed / lerpDuration);
            screenRend.color = colorScreen;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
