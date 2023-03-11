using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{
    [SerializeField] private Text scoreTextP1;
    [SerializeField] private Text scoreTextP2;
    [SerializeField] private Text scoreTextTotal;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
