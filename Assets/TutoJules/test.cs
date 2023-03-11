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
    [SerializeField] public Sprite[] frogSprites;
    [SerializeField] public Sprite[] eyeSprites;
    [SerializeField] public Sprite[] pizzaSprites;
    [SerializeField] public Sprite[] snakeSprites;

    // Cursor and graduate sprites
    [SerializeField] public Sprite cursorSprite;
    [SerializeField] public Sprite graduateSprite;

    [SerializeField] private string solution = "grenouille";

    // Cursor/Graduate
    [SerializeField] private GameObject cursor;
    [SerializeField] public Transform[] cursorTransforms;

    private Sprite[] curSpriteSet;
    private int idxSprite = 0;
    // Timer
    private float nextActionTime = 0.0f;
    public float timeBetweenTwoSpriteRes = 0.2f;

    // Player score
    private int score = 0;
    private int player2SpeedScore = 0;
    private int player1PrecisionScore = 0;

    // game finished
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
        image = GetComponent<Image>();

        int idxSpriteSet = Random.Range(0, 4);

        switch (idxSpriteSet) {
            case 0:
                curSpriteSet = frogSprites;
                break;
            case 1:
                curSpriteSet = eyeSprites;
                break;
            case 2:
                curSpriteSet = pizzaSprites;
                break;
            case 3:
                curSpriteSet = snakeSprites;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished && Time.time > nextActionTime) {
            nextActionTime += timeBetweenTwoSpriteRes;

            // We are at the end of the last image and the player
            // has not guessed anything,
            // => the game ends without giving any score
            if (idxSprite == curSpriteSet.Length) {
                finished = true;
            } else {
                // Change the sprite here
                image.sprite = curSpriteSet[idxSprite % curSpriteSet.Length]; // Change the sprite of the Image object
                // Set a new position for the cursor
                cursor.transform.position = cursorTransforms[idxSprite % cursorTransforms.Length].position;

                idxSprite += 1;
            }
        }
    }

    void ComputeFinalScore(int player1guess, int player2result) {
        // Speed between 1 and 10:
        // - 1: the player2 guess at the full resolution (10)
        // - 10: the players2 guess at the resolution the most degraded (1)
        player2SpeedScore = 10 - player2result + 1;
        // Team score avec le player 1, between:
        // - 10 for good guess
        // - 1 for opposite guess
        player1PrecisionScore = 10 - System.Math.Abs(player1guess - player2result);
        score = player1PrecisionScore * player2SpeedScore;
    }

    public void InputFieldTest()
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
