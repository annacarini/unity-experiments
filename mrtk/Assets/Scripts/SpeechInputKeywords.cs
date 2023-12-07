using MixedReality.Toolkit.Subsystems;
using MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechInputKeywords : MonoBehaviour {

    KeywordRecognitionSubsystem keywordRecognitionSubsystem;

    public GameObject obj;  // temp


    void Start() {
        // Get the first running phrase recognition subsystem.
        keywordRecognitionSubsystem = XRSubsystemHelpers.GetFirstRunningSubsystem<KeywordRecognitionSubsystem>();

        // If we found one...
        if (keywordRecognitionSubsystem != null) {
            // Register a keyword and its associated action with the subsystem
            //keywordRecognitionSubsystem.CreateOrGetEventForKeyword("menu").AddListener(() => Debug.Log("Keyword recognized"));
            keywordRecognitionSubsystem.CreateOrGetEventForKeyword("menu").AddListener(toggleActiveObject);
        }
    }

    private void toggleActiveObject() {
        obj.SetActive(!obj.activeSelf);
    }

    void Update() {
        
    }
    
}
