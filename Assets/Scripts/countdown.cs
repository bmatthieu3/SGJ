using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] public Sprite[] numbersSprites;
    private float timeBetweenTwoSpriteRes = 1.0f;
    private float nextActionTime = 0.0f;
    private int idxSprite = 0;
    private int numSpriteSets;
     

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        nextActionTime = Time.time + timeBetweenTwoSpriteRes;
        numSpriteSets = numbersSprites.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime && idxSprite < numSpriteSets)
        {
            nextActionTime += timeBetweenTwoSpriteRes;
            image.sprite = numbersSprites[idxSprite]; // Change the sprite of the Image object
            idxSprite += 1;
        }
    }

}
