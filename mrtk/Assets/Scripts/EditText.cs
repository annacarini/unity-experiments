using MixedReality.Toolkit.UX;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditText : MonoBehaviour {

    [SerializeField]
    GameObject outputTextObj;

    [SerializeField]
    GameObject inputTextObj;

    private TextMeshProUGUI textOutputComponent;
    private MRTKTMPInputField textInputComponent;

    void Awake() {
        textOutputComponent = outputTextObj.GetComponent<TextMeshProUGUI>();
        textInputComponent = inputTextObj.GetComponent<MRTKTMPInputField>();
    }


    public void editText() {
        textOutputComponent.text = textInputComponent.text;
    }
}
