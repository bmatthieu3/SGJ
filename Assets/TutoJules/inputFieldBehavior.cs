using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputFieldLogger : MonoBehaviour
{
    public InputField inputField;

    private void Start()
    {
        // Attach a listener to the onValueChanged event
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
    }

    private void OnInputFieldValueChanged(string newValue)
    {
        // Print the new value to the console
        Debug.Log("New value: " + newValue);
    }
}
