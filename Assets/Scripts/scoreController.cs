using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{
    [SerializeField] private Text scoreTextP1;
    [SerializeField] private Text scoreTextP2;
    [SerializeField] private Text scoreTextTotal;
    [SerializeField] private Sprite[] scoreSprites;
    [SerializeField] private Image[] noenoeils;

    private int limiteBad = 10;
    private int limiteGood = 90;

    public int scoreP1 = 4;
    public int scoreP2 = 6;
    // Start is called before the first frame update
    void Start()
    {
        int scoreTotal = scoreP1 * scoreP2;
        if (scoreP2 >= 2)
            scoreTextP2.text = scoreP2 + " pts";
        else
            scoreTextP2.text = scoreP2 + " pt";
        scoreTextP1.text = scoreP1 + "";

        if (scoreTotal >= 2)
            scoreTextTotal.text = scoreTotal + " pts";
        else
            scoreTextTotal.text = scoreTotal + " pt";

        Debug.Log(scoreSprites.Length);

        if (scoreTotal < limiteBad)
        {
            noenoeils[0].sprite = scoreSprites[0]; // déçu
            noenoeils[1].sprite = scoreSprites[0]; // déçu
        }
        else if (scoreTotal < limiteGood)
        {
            noenoeils[0].sprite = scoreSprites[1]; // heureux
            noenoeils[1].sprite = scoreSprites[1]; // heureux
        }
        else
        {
            noenoeils[0].sprite = scoreSprites[2]; // très heureux
            noenoeils[1].sprite = scoreSprites[2]; // très heureux
        }
    }

    // Update is called once per frame
    void Update()
    {
        int scoreTotal = scoreP1 * scoreP2;

        if (scoreP2 >= 2)
            scoreTextP2.text = scoreP2 + " pts";
        else
            scoreTextP2.text = scoreP2 + " pt";
        scoreTextP1.text = scoreP1 + "";

        if (scoreTotal >= 2)
            scoreTextTotal.text = scoreTotal + " pts";
        else
            scoreTextTotal.text = scoreTotal + " pt";

        if (scoreTotal < limiteBad)
        {
            noenoeils[0].sprite = scoreSprites[0]; // déçu
            noenoeils[1].sprite = scoreSprites[0]; // déçu
        }
        else if (scoreTotal < limiteGood)
        {
            noenoeils[0].sprite = scoreSprites[1]; // heureux
            noenoeils[1].sprite = scoreSprites[1]; // heureux
        }
        else
        {
            noenoeils[0].sprite = scoreSprites[2]; // très heureux
            noenoeils[1].sprite = scoreSprites[2]; // très heureux
        }
    }
}
