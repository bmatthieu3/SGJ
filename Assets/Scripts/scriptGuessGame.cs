using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;
using System.IO;

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

    private int width, height;

    private int[] widths = {7, 14, 27, 34, 41, 55, 69, 104, 276, 691};
    private int[] heights = {6, 12, 23, 29, 35, 47, 59, 88, 235, 588};

    public ImageData[] imageList;
    // Cursor and graduate sprites
    [SerializeField] private string[] solutions;
    [SerializeField] private Texture2D texture;
    [SerializeField] private Sprite sprite;
    // Cursor/Graduate
    [SerializeField] private GameObject cursor;
    [SerializeField] public Transform[] cursorTransforms;
    private int M_idxSprite;

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


    [System.Serializable]
    public class ImageData
    {
        public int id;
        public string name;
        public string path;
        public string source;
        public string license;
        public string[] solution;
    }

    [System.Serializable]
    public class ImageDataList
    {
        public ImageData[] images;
    }

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

        texture = new Texture2D(1, 1);
        byte[] bytes = File.ReadAllBytes(Application.dataPath + "/" + imageList[M_idxSprite].path);
        texture.LoadImage(bytes);

        width = texture.width;
        height = texture.height;

        Texture2D resizedTexture = Resize(texture,
                        Convert.ToInt32( width  * 0.01),
                        Convert.ToInt32( height * 0.01) );
                sprite = Sprite.Create(resizedTexture, new Rect(0, 0, resizedTexture.width, resizedTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
                image.sprite = sprite;

        sprite = Sprite.Create(resizedTexture, new Rect(0, 0, resizedTexture.width, resizedTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        image.sprite = sprite;
        /*Debug.Log("imageList: " + imageList);
        foreach (ImageData exampleData in imageList)
        {
            Debug.Log("ID: " + exampleData.id);
            Debug.Log("Name: " + exampleData.name);
            Debug.Log("Path: " + exampleData.path);
            Debug.Log("Source: " + exampleData.source);
            Debug.Log("License: " + exampleData.license);
            Debug.Log("Solutions: " + string.Join(", ", exampleData.solution));
        }*/
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

    public void SetSpriteSet(int idxSpriteSet)
    {
        M_idxSprite = idxSpriteSet;
        solutions = imageList[M_idxSprite].solution;
        Debug.Log("SetSpriteSet: " + idxSpriteSet + " " + string.Join(", ", solutions));
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
            if (idxSprite == widths.Length) {
                int player1guess = bet.bet_value;
                int player2perf = idxSprite;
                ComputeScore(player1guess, player2perf);

                finished = true;
            } else {
                soundManager.PlaySoundClic();

                // Change the sprite here
                Texture2D resizedTexture = Resize(texture,
                        Convert.ToInt32( widths[idxSprite] ),
                        Convert.ToInt32( heights[idxSprite]) );
                sprite = Sprite.Create(resizedTexture, new Rect(0, 0, resizedTexture.width, resizedTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
                image.sprite = sprite; // Change the sprite of the Image object
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

    private Texture2D Resize(Texture2D texture, int width, int height)
    {
        RenderTexture rt = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.ARGB32);
        rt.filterMode = FilterMode.Bilinear;

        if (width == 0)
            width = 1;
        if (height == 0)
            height = 1;

        RenderTexture.active = rt;
        Graphics.Blit(texture, rt);
        Texture2D result = new Texture2D(width, height);
        result.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        result.Apply();

        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(rt);

        return result;
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
