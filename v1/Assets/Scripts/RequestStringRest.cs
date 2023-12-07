using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class RequestStringRest : MonoBehaviour {

    private TextMeshProUGUI textComponent;
    
    [SerializeField]
    GameObject outputTextObj;

    void Start() {
        textComponent = outputTextObj.GetComponent<TextMeshProUGUI>();
    }


    // Prendi i dati da server REST
    private string URL = "https://annacarini.pythonanywhere.com/string?";

    public void requestString() {
        int i = Random.Range(0,4);
        StartCoroutine(getData(URL + i));       // manda la richiesta in un altro thread (coroutine) perche' non riesci a inviarla + ricevere risposta in un unico frame
    }

    IEnumerator getData(string url) {           // ogni metodo che avvii in una coroutine deve restituire un IEnumerator
        using (UnityWebRequest request = UnityWebRequest.Get(url)) {
            yield return request.SendWebRequest();                          // invia la richiesta e aspetta la risposta

            if (request.result == UnityWebRequest.Result.ConnectionError) {
                Debug.LogError(request.error);
            }
            else {
                string data = request.downloadHandler.text;
                textComponent.text = data;
            }
        }
    }

}
