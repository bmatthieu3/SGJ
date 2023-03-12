using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bet : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject cursor;
    [SerializeField] public Transform[] cursorTransforms;
    public int bet_value;

    public bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        bet_value = 1;
        cursor.transform.position = cursorTransforms[0 % cursorTransforms.Length].position;

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

        //After we have waited 5 seconds print the time again.
        finished = true;
    } 

    public void ButtonTest(int bet)
    {
        Debug.Log("Pari : " + bet);
        bet_value = bet;
        int idxSprite = bet - 1;
        cursor.transform.position = cursorTransforms[idxSprite % cursorTransforms.Length].position;

        StartCoroutine(SetFinishedInSeconds(2.0f));
    }
}
