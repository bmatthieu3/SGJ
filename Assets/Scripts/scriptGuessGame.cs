using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script is used to manage the game : Player 2 has to guess the image, which is displayed on the screen.
 */

public class scriptGuessGame : MonoBehaviour
{
    [SerializeField] private Image image;
    // Input field
    [SerializeField] public InputField inputField;
    // Sprites
    [SerializeField] public Sprite[] frogSprites;
    [SerializeField] public Sprite[] eyeSprites;
    [SerializeField] public Sprite[] pizzaSprites;
    [SerializeField] public Sprite[] snakeSprites;
    private int numSpriteSets = 4;

    // Cursor and graduate sprites
    [SerializeField] public Sprite cursorSprite;
    [SerializeField] public Sprite graduateSprite;

    [SerializeField] private string[] solutions;

    private Sprite[] curSpriteSet;
    private int idxSprite = 0;
    // Timer
    private float nextActionTime = 0.0f;
    public float timeBetweenTwoSpriteRes = 0.2f;

    // Player score
    private int score = 0;

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
                solutions = new string[] {"grenouille", "frog", "froggy", "froggie"};
                break;
            case 1:
                curSpriteSet = eyeSprites;
                solutions = new string[] {"oeil", "eye", "eyes", "œil"};
                break;
            case 2:
                curSpriteSet = pizzaSprites;
                solutions = new string[] {"pizza", "pizz", "piza", "pizzz"};
                break;
            case 3:
                curSpriteSet = snakeSprites;
                solutions = new string[] {"serpent", "snake", "snaky", "snaky snake"};
                break;
            default:
                break;
        }
    }

    void ComputeScore(int player1guess, int player2result) {
        // Speed between 1 and 10:
        // - 1: the player2 guess at the full resolution (10)
        // - 10: the players2 guess at the resolution the most degraded (1)
        int Player2Speed = 10 - player2result + 1;
        // Team score avec le player 1, between:
        // - 10 for good guess
        // - 1 for opposite guess
        int Player1Precision = 10 - System.Math.Abs(player1guess - player2result);
        score = Player1Precision * Player2Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished && Time.time > nextActionTime)
        {
            nextActionTime += timeBetweenTwoSpriteRes;

            // We are at the end of the last image and the player
            // has not guessed anything,
            // => the game ends without giving any score
            if (idxSprite == curSpriteSet.Length) {
                ComputeScore(1, 10);
                finished = true;
            } else {
                // change the sprite here
                image.sprite = curSpriteSet[idxSprite % curSpriteSet.Length]; // Change the sprite of the Image object
                idxSprite += 1;
            }
        }
    }
}
