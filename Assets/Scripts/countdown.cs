using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] public Sprite[] numbersSprites;
    private float timeBetweenTwoSpriteRes = 0.8f;
    private float nextActionTime = 0.0f;
    private float startTime = 0.0f;
    private int idxSprite = 0;
    private int numSpriteSets;
    private bool finished = false;
     
    // Previous frame
    [SerializeField] private bet bet;

    private SoundManager soundManager;

    IEnumerator StartAfterPrevSlide()
    {
        yield return new WaitUntil(() => {
            var transition = bet.isFrameFinished();
            if (transition) {
                startTime = Time.time;
                nextActionTime = timeBetweenTwoSpriteRes;
                idxSprite = 0;
            }

            return transition;
        });
    }

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAfterPrevSlide());

        image = GetComponent<Image>();
        numSpriteSets = numbersSprites.Length;
    }

    public bool isFrameFinished() {
        return finished;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime) > nextActionTime && idxSprite <= numSpriteSets)
        {
            if (idxSprite == numSpriteSets) {
                finished = true;
                idxSprite += 1;
                return;
            }

            soundManager.PlaySoundCompteur();
            nextActionTime += timeBetweenTwoSpriteRes;
            image.sprite = numbersSprites[idxSprite]; // Change the sprite of the Image object
            idxSprite += 1;
        }
    }
}
