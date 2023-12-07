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

public class MenuMain : MonoBehaviour {


    [SerializeField]
    GameObject menuInputKeyboard;

    [SerializeField]
    GameObject modelLoader;
    private LoadModel modelLoaderScript;

    private void Start() {
        modelLoaderScript = modelLoader.GetComponent<LoadModel>();

        // Chiudi gli altri menu
        menuInputKeyboard.SetActive(false);
    }

    /* PRIMO PULSANTE */
    public void toggleMenuInputKeyboard() {
        menuInputKeyboard.SetActive(!menuInputKeyboard.activeSelf);

        // Posiziona il menu accanto a quello principale
        menuInputKeyboard.transform.rotation = gameObject.transform.rotation;
        menuInputKeyboard.transform.position = gameObject.transform.position;
        menuInputKeyboard.transform.position += 0.2f * gameObject.transform.right;
    }


    /* SECONDO PULSANTE */

    GameObject wrapper;
    string filePath = "localhost:8080/plantSmall1.obj";
    //string filePath = "localhost:8080/chiave.obj";

    // Callback function for the model loader
    private void setModel(GameObject model) {
        wrapper = model;
        Debug.Log("Model has been imported");
    }

    public void LoadOBJModel() {
        modelLoaderScript.loadModel(filePath, wrapper, setModel);
        
    }

<<<<<<< Updated upstream
=======
    // Per il pulsante che apre il menu dell'hand menu
    public void toggleMenu() {
        gameObject.SetActive(!gameObject.activeSelf);
        if (gameObject.activeSelf) {
            menuInputKeyboard.SetActive(false);
            gameObject.GetComponent<RadialView>().enabled = true;
        }

    }
>>>>>>> Stashed changes
}
