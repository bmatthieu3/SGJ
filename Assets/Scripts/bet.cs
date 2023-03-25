using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class bet : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject cursor;
    [SerializeField] public Transform[] cursorTransforms;
    [SerializeField] private GameObject[] buttonObject;
    public int bet_value;

    public bool finished = false;

    [SerializeField] private scriptGuessGame scriptGuessGame;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        bet_value = 1;
        cursor.transform.position = cursorTransforms[0 % cursorTransforms.Length].position;

        // Load the json file from disk
        string filePath = Application.dataPath + "/sprites/images.json";
        string jsonString = File.ReadAllText(filePath);
        // Debug.Log("jsonString: " + jsonString);

        // parse the JSON string into an ImageDataList object
        scriptGuessGame.ImageDataList imageDataList = JsonUtility.FromJson<scriptGuessGame.ImageDataList>(jsonString);
        scriptGuessGame.imageList = imageDataList.images;

        int nbOfImages = scriptGuessGame.imageList.Length;
        // int idxSpriteSet = 7;
        int idxSpriteSet = UnityEngine.Random.Range(0, nbOfImages - 1);
        Debug.Log("nbOfImages : " + nbOfImages);
        Debug.Log("idxSpriteSet : " + idxSpriteSet);
        scriptGuessGame.SetSpriteSet(idxSpriteSet);

        // Load image from file
        Texture2D texture = new Texture2D(1, 1);
        byte[] bytes = File.ReadAllBytes(Application.dataPath + "/" + scriptGuessGame.imageList[idxSpriteSet].path);
        texture.LoadImage(bytes);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        image.sprite = sprite;
        // image.sprite = scriptGuessGame.curSpriteSet[scriptGuessGame.curSpriteSet.Length - 1];
    }

    public bool isFrameFinished() {
        return finished;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetFinishedInSeconds(float seconds)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(seconds);

        //After we have waited n seconds print the time again.
        finished = true;
    }

    public void ButtonTest(int bet)
    {
        for (int i = 0; i < buttonObject.Length; i++)
        {
            buttonObject[i].SetActive(false);
        }

        FindObjectOfType<SoundManager>().PlaySoundButton();

        Debug.Log("Pari : " + bet);
        bet_value = bet;
        int idxSprite = bet - 1;
        cursor.transform.position = cursorTransforms[idxSprite % cursorTransforms.Length].position;

        StartCoroutine(SetFinishedInSeconds(2.0f));
    }
}
