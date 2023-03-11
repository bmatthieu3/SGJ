using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public GameObject unNom;
    [SerializeField] private Image nomImage;

    public InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        nomImage = unNom.GetComponent<Image>();
        inputField = unNom.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ButtonTest()
    {
        Debug.Log("Boutton fonctionne");
    }

    public void InputFieldTest()
    {
        string inputText = inputField.text;
        Debug.Log("Input field text: " + inputText);
    }

}
