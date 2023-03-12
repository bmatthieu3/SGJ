using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private scriptGuessGame scriptGuessGame;
    [SerializeField] private countdown countdown;
    [SerializeField] private bet bet;
    [SerializeField] private scoreController score;

    private int idxCanvas = 0;

    [SerializeField] private GameObject canvas4;
    [SerializeField] private GameObject canvas5;
    [SerializeField] private GameObject canvas6;
    [SerializeField] private GameObject canvas7; // score canvas

    // Start is called before the first frame update
    void Start()
    {
        /*scriptGuessGame = FindObjectOfType<scriptGuessGame>();
        countdown = FindObjectOfType<countdown>();
        bet = FindObjectOfType<bet>();*/

        canvas4.SetActive(true);
        canvas5.SetActive(false);
        canvas6.SetActive(false);
        canvas7.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (idxCanvas == 0 && bet.isFrameFinished()) {
            canvas4.SetActive(false);
            canvas5.SetActive(true);
            idxCanvas = 1;
        }

        if (idxCanvas == 1 && countdown.isFrameFinished()) {
            canvas5.SetActive(false);
            canvas6.SetActive(true);
            idxCanvas = 2;
        }

        if (idxCanvas == 2 && scriptGuessGame.isFrameFinished()) {
            canvas6.SetActive(false);
            canvas7.SetActive(true);
            idxCanvas = 3;
        }
    }
}
