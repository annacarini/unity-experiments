using Dummiesman;
using MixedReality.Toolkit.SpatialManipulation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ModelLoader : MonoBehaviour {

    public void loadModel(string url, GameObject wrapper, Action<GameObject> callback=null) {
        StartCoroutine(loadModelCoroutine(url, wrapper, callback));
    }


    private IEnumerator loadModelCoroutine(string url, GameObject wrapper, Action<GameObject> callback=null) {

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success) {
            Debug.Log("WWW ERROR: " + request.error);
            Debug.Log("URL: " + url);
        }
        else {
            //Load OBJ Model
            MemoryStream textStream = new MemoryStream(Encoding.UTF8.GetBytes(request.downloadHandler.text));
      
            if (wrapper != null) {
                Destroy(wrapper);       // cosi' abbiamo un solo modello per volta e non intasiamo la memoria
            }

            wrapper = new OBJLoader().Load(textStream);

            // Attach box collider
            addBoxCollider(wrapper);

            // Attach object manipulator
            wrapper.AddComponent<ObjectManipulator>();

            if (callback != null)
                callback(wrapper);
        }
    }

    private void addBoxCollider(GameObject model) {
        // Attach box collider, center it and resize it
        BoxCollider boxCollider = model.AddComponent<BoxCollider>();
        Bounds bounds = GetBounds(model);
        boxCollider.center = bounds.center;
        boxCollider.size = bounds.size;
    }

    // Il file OBJ puo' essere costituito di diversi "figli". Per avere i bounds di tutto
    // il modello prendi tutti i bounds dei figli e li incapsuli in un bounds solo
    private Bounds GetBounds(GameObject gameObj) {
        Bounds bound = new Bounds(gameObj.transform.position, Vector3.zero);
        var rList = gameObj.GetComponentsInChildren(typeof(Renderer));
        foreach (Renderer r in rList) {
            bound.Encapsulate(r.bounds);
        }
        return bound;
    }


    /*
    public void FitOnScreen() {
        Bounds bound = GetBounds(model);
        Vector3 boundSize = bound.size;
        float diagonal = Mathf.Sqrt((boundSize.x * boundSize.x) + (boundSize.y * boundSize.y) + (boundSize.z * boundSize.z)); //Get box diagonal
        Camera.main.orthographicSize = diagonal / 2.0f;
        Camera.main.transform.position = bound.center;
    }
    */
}
