using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    
    [SerializeField]
    GameObject menu;

    void Start() {
        //menu.SetActive(false);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.M)) {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
