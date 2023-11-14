using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelButtons : MonoBehaviour {

    private TMPro.TMP_Text textElement;
    private int counter = 0;

    // Start is called before the first frame update
    void Start() {
        textElement = this.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void increaseCounter() {
        counter++;
        textElement.text = "Counter: " + counter;
    }

    public void decreaseCounter() {
        counter--;
        textElement.text = "Counter: " + counter;
    }
}
