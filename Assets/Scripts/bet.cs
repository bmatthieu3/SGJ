using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        int idxSpriteSet = UnityEngine.Random.Range(0, 4);
        scriptGuessGame.SetSpriteSet(idxSpriteSet);

        image.sprite = scriptGuessGame.curSpriteSet[scriptGuessGame.curSpriteSet.Length - 1];
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
