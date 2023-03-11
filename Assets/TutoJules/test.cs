using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public GameObject gameObj;
    [SerializeField] public Sprite m_Sprite;

    [SerializeField] private Image nomImage;

    private float nextActionTime = 0.0f;
    public float period = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        nomImage = gameObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Time.time > nextActionTime ) {
            nextActionTime += period;
            // change the sprite here
        }
    }

    public void ButtonTest()
    {
        Debug.Log("Boutton fonctionne");
        nomImage.sprite = m_Sprite;
    }

    public void InputFieldTest()
    {
        // string newValue = unNom.GetComponent<InputField>().text;
        string newValue = "test";
        Debug.Log("InputField fonctionne : " + newValue);
    }

}
