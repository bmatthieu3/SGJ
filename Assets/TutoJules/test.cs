using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class test : MonoBehaviour
{
    [SerializeField] private Image image;
    // Input field
    [SerializeField] public InputField inputField;
    // Sprites
    [SerializeField] public Sprite[] newSprites;
    private int idxSprite = 0;
    // Timer
    private float nextActionTime = 0.0f;
    public float timeBetweenTwoSpriteRes = 0.2f;

    [SerializeField] private string solution = "grenouille";


    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Time.time > nextActionTime) {
            nextActionTime += timeBetweenTwoSpriteRes;
            // change the sprite here
            image.sprite = newSprites[idxSprite % newSprites.Length]; // Change the sprite of the Image object
            idxSprite += 1;
        }
    }


    public void ButtonTest()
    {
        Debug.Log("Boutton fonctionne");

    }

    public void checkSolution()
    {
        string inputText = inputField.text;
        string lower_str = inputText.ToLower();
        StringBuilder sb = new StringBuilder();
        foreach (char c in lower_str)
        {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_') {
                sb.Append(c);
            }
        }
        string answer = sb.ToString();
        Debug.Log("Input field text: " + answer);

        if (answer == solution)
        {
            Debug.Log(inputText + " est la bonne réponse");
        }
        else
        {
            Debug.Log(inputText + " est la mauvaise réponse");
        }

    }

}
