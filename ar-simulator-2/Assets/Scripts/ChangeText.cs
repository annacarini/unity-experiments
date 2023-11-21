using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]

public class ChangeText : ClickableObject {

    private TextMeshProUGUI textComponent;
    
    void Start() {
        textComponent = this.gameObject.GetComponent<TextMeshProUGUI>();
    }
    
    public override void OnClick() {
        textComponent.text = "AAAA";
    }
}
