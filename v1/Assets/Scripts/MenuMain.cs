using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using Dummiesman;
using System.IO;
using System.Text;
using MixedReality.Toolkit.SpatialManipulation;
using Unity.VisualScripting;
using MixedReality.Toolkit.UX;

public class MenuMain : MonoBehaviour {


    [SerializeField]
    GameObject menuInputKeyboard;

    [SerializeField]
    GameObject pinButton;



    private void Start() {
        // Chiudi gli altri menu
        if (menuInputKeyboard) menuInputKeyboard.SetActive(false);
    }

    /* PRIMO PULSANTE */
    public void toggleMenuInputKeyboard() {
        menuInputKeyboard.SetActive(!menuInputKeyboard.activeSelf);

        // Posiziona il menu accanto a quello principale
        menuInputKeyboard.transform.rotation = gameObject.transform.rotation;
        menuInputKeyboard.transform.position = gameObject.transform.position;
        menuInputKeyboard.transform.position += 0.2f * gameObject.transform.right;
    }



    // Per il pulsante che apre il menu dell'hand menu
    public void toggleMenu() {
        gameObject.SetActive(!gameObject.activeSelf);
        if (gameObject.activeSelf) {
            if (menuInputKeyboard) menuInputKeyboard.SetActive(false);
            // Fai in modo che il menu ti segue
            gameObject.GetComponent<RadialView>().enabled = true;
            // Untoggle pin
            pinButton.GetComponent<PressableButton>().ForceSetToggled(false, false);    // ForceSetToggled(bool active, bool fireEvents = true)
        }
    }
}
