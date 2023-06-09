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

    [SerializeField] private GameObject canvas23; // tuto canvas
    [SerializeField] private GameObject canvas4 ; // bet canvas
    [SerializeField] private GameObject canvas5 ; // countdown canvas
    [SerializeField] private GameObject canvas6 ; // game canvas
    [SerializeField] private GameObject canvas7 ; // score canvas

    [SerializeField] GameObject screen2;
    [SerializeField] GameObject screen3;
    [SerializeField] GameObject screen35;

    private SoundManager soundManager;
    private scoreController scoreContr;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.SetMusicGame();

        scoreContr = FindObjectOfType<scoreController>();
    }


    // Start is called before the first frame update
    void Start()
    {
        /*scriptGuessGame = FindObjectOfType<scriptGuessGame>();
        countdown = FindObjectOfType<countdown>();
        bet = FindObjectOfType<bet>();*/

        canvas23.SetActive(true);
        canvas4.SetActive(false);
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

            soundManager.SetMusicMenuOrScore();
         
        }
    }

    public void GoScreen3()
    {
        soundManager.PlaySoundButton();
        screen3.SetActive(true);
        screen2.SetActive(false);
    }

    public void goTuto()
    {
        soundManager.PlaySoundButton();
        screen3.SetActive(false);
        screen35.SetActive(true);
    }

    public void GoScreen4()
    {
        soundManager.PlaySoundButton();
        canvas23.SetActive(false);
        canvas4.SetActive(true);
    }
}
