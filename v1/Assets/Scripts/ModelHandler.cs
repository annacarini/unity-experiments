using MixedReality.Toolkit.UX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ModelLoader))]
[RequireComponent(typeof(DialogPool))]
public class ModelHandler : MonoBehaviour {

    private int current_instruction = 0;
    private int number_of_instructions = 2;

    private ModelLoader modelLoader;
    private GameObject modelWrapper;
    string filePath = "localhost:5000/instruction?index=";

    private bool waitingModel = false;

    private DialogPool dialogPool;
    private IDialog loadingPanel;

    void Start() {
        modelLoader = gameObject.GetComponent<ModelLoader>();

        // Pannello di caricamento
        dialogPool = gameObject.GetComponent<DialogPool>();
        loadingPanel = dialogPool.Get();
    }


    public void nextInstruction() {
        current_instruction++;
        if (current_instruction >= number_of_instructions) current_instruction = 0;       // da togliere
        skipToInstruction(current_instruction);
    }

    public void previousInstruction() {
        current_instruction--;
        if (current_instruction < 0) current_instruction = number_of_instructions-1;       // da togliere
        skipToInstruction(current_instruction);
    }

    private void skipToInstruction(int i) {
        if (!waitingModel) {
            // Elimina modello precedente
            if (modelWrapper) Destroy(modelWrapper);

            // Mostra schermata di caricamento
            prepareLoadingPanel(loadingPanel);
            loadingPanel.Show();

            // Richiedi nuovo modello
            modelLoader.loadModel(filePath + i, modelWrapper, setModel);
            waitingModel = true;
        }
    }

    // Callback function for the model loader
    private void setModel(GameObject model) {

        // Nascondi pannello caricamento
        Debug.Log("sto per fare dismiss");
        loadingPanel.Dismiss();

        modelWrapper = model;
        positionModel(modelWrapper);
        Debug.Log("Model has been imported");

        waitingModel = false;
    }


    // Questa va cambiata col posizionamento del modello in corrispondenza dell'oggetto vero
    private void positionModel(GameObject model) {
        // Position the object
        //model.transform.localScale = new Vector3(-1, 1, 1);
        model.transform.position = Camera.main.transform.position + 0.5f * Camera.main.transform.forward;         // temporaneo
    }


    // Dialog che dice che il modello sta caricando
    private void prepareLoadingPanel(IDialog panel) {
        loadingPanel.SetHeader("Waiting for the model to load");
        loadingPanel.SetBody("...");
    }

}
