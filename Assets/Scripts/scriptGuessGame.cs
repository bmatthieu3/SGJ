using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

/*
 * This script is used to manage the game : Player 2 has to guess the image, which is displayed on the screen.
 */

public class scriptGuessGame : MonoBehaviour
{
    [SerializeField] private Image image;
    // Input field
    [SerializeField] public UnityEngine.UI.InputField inputField;
    // Sprites
    [SerializeField] public Sprite[] frogSprites;
    [SerializeField] public Sprite[] eyeSprites;
    [SerializeField] public Sprite[] pizzaSprites;
    [SerializeField] public Sprite[] snakeSprites;
    [SerializeField] public Sprite[] potatosSprites;
    [SerializeField] public Sprite[] octopusSprites;
    [SerializeField] public Sprite[] mugSprites;
    // Cursor and graduate sprites
    [SerializeField] private string[] solutions;
    // Cursor/Graduate
    [SerializeField] private GameObject cursor;
    [SerializeField] public Transform[] cursorTransforms;

    // Previous frame
    [SerializeField] private countdown countdown;
    [SerializeField] private bet bet;

    public Sprite[] curSpriteSet;
    public int idxSprite = 0;
    // Timer
    public float startTime = 0.0f;
    private float nextActionTime = 0.0f;
    public float timeBetweenTwoSpriteRes = 0.2f;

    // Player score
    private int score = 0;
    public int player2SpeedScore = 0;
    public int player1PrecisionScore = 0;

    // game finished
    private bool finished = false;

    //Sound
    private SoundManager soundManager;

    void Awake()
    {
        Debug.Log("Awake");
        soundManager = FindObjectOfType<SoundManager>();

    }

    IEnumerator StartAfterPrevSlide()
    {
        yield return new WaitUntil(() => {
            var transition = countdown.isFrameFinished();
            if (transition) {
                startTime = Time.time;
            }

            return transition;
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAfterPrevSlide());

        image = GetComponent<Image>();

        inputField.ActivateInputField();
    }

    void ComputeScore(int player1guess, int player2result) {
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

    public void SetSpriteSet(int idxSpriteSet) {
        switch (idxSpriteSet) {
            case 0:
                curSpriteSet = frogSprites;
                solutions = new string[] {"grenouille", "frog", "froggy", "froggie", "crapeau", "ha"};
                break;
            case 1:
                curSpriteSet = eyeSprites;
                solutions = new string[] {"oeil", "eye", "eyes", "œil", "noenoeil", "ha"};
                break;
            case 2:
                curSpriteSet = pizzaSprites;
                solutions = new string[] {"pizza", "pizz", "piza", "pizzz", "ha"};
                break;
            case 3:
                curSpriteSet = snakeSprites;
                solutions = new string[] {"serpent", "snake", "snaky", "snaky snake", "ha"};
                break;
            case 4:
                curSpriteSet = potatosSprites;
                solutions = new string[] {"patate", "pomme de terre", "pommes de terre", "patates", "potatos", "potato", "cartof", "kartoffel", "ha"};
                break;
            case 5:
                curSpriteSet = octopusSprites;
                solutions = new string[] {"poulpe", "poulp", "octopus", "pieuvre", "poulpi", "octopussy", "octopussy poulpe", "ha"};
                break;
            case 6:
                curSpriteSet = mugSprites;
                solutions = new string[] {"mug", "tasse", "verre", "gamejam", "shadok", "ha"};
                break;
            default:
                break;
        } 
    } 

    // Update is called once per frame
    void Update()
    {
        //if (inputField.gameObject.activeSelf)
        //{
        //    if (Input.GetKeyDown(KeyCode.Return))
        //    {
        //        inputField.ActivateInputField();
        //    }
        //}

        if (!finished && (Time.time - startTime) > nextActionTime) {
            nextActionTime += timeBetweenTwoSpriteRes;

            // We are at the end of the last image and the player
            // has not guessed anything,
            // => the game ends without giving any score
            if (idxSprite == curSpriteSet.Length) {
                int player1guess = bet.bet_value;
                int player2perf = idxSprite;
                ComputeScore(player1guess, player2perf);

                finished = true;
            } else {
                soundManager.PlaySoundClic();

                // Change the sprite here
                image.sprite = curSpriteSet[idxSprite % curSpriteSet.Length]; // Change the sprite of the Image object
                // Set a new position for the cursor
                cursor.transform.position = cursorTransforms[idxSprite % cursorTransforms.Length].position;

                idxSprite += 1;
            }
        }
    }

    public void resetColor()
    {
        if (inputField.text == "" || inputField.text.Length <= 1)
            inputField.image.color = Color.white;
    }

    public bool isFrameFinished() {
        return finished;
    }

    public void checkSolution()
    {
        string inputText = inputField.text;
        if (inputText == "")
            return;
        string lower_str = inputText.ToLower();
        StringBuilder sb = new StringBuilder();
        foreach (char c in lower_str)
        {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ' ' || c == 'œ') {
                sb.Append(c);
            }
        }
        string answer = sb.ToString();
        Debug.Log("Input field text: " + answer);

        bool found = false;
        foreach (string solution in solutions)
        {
            if (answer == solution)
            {
                found = true;
                break;
            }
        }

        if ( found )
        {
            Debug.Log(inputText + " est la bonne réponse");
            inputField.image.color = Color.green;

            int player1guess = bet.bet_value;
            int player2perf = idxSprite;
            ComputeScore(player1guess, player2perf);

            finished = true;
        }
        else
        {
            Debug.Log(inputText + " est la mauvaise réponse");
            inputField.image.color = Color.red;
        }
    }
}
