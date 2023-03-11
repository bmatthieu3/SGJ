using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void InputFieldTest()
    {
        string inputText = inputField.text;
        Debug.Log("Input field text: " + inputText);
    }

}
