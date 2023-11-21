using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : ClickableObject {
    public override void OnClick() {
        gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }
}
