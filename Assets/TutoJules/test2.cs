using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class test2 : MonoBehaviour
{
    public GameObject gameObj;

    [SerializeField] private Image nomImage;
    [SerializeField] private InputField inputField;

    [SerializeField] private string solution = "grenouille";

    private float nextActionTime = 0.0f;
    public float period = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        nomImage = gameObj.GetComponent<Image>();
        inputField = gameObj.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ButtonTest()
    {
        Debug.Log("Boutton fonctionne");
    }

    public void checkSolution()
    {
        string inputText = inputField.text;
        string lower_str = inputText.ToLower();
        StringBuilder sb = new StringBuilder();
        foreach (char c in lower_str)
        {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_') {
                sb.Append(c);
            }
        }
        string answer = sb.ToString();
        Debug.Log("Input field text: " + answer);

        if (answer == solution)
        {
            Debug.Log(inputText + " est la bonne réponse");
        }
        else
        {
            Debug.Log(inputText + " est la mauvaise réponse");
        }

    }

}
