using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuOptions : MonoBehaviour {
    
    public const int NO_SCRIPT = -1;
    public const int PLACE_ON_PLANE = 0;
    public const int PLACE_MULTIPLE_OBJECTS = 1;
    public const int CAST_RAY_ON_CLICK = 2;

    public GameObject[] objects;

    private GameObject selectedObject;
    private int selectedScript = NO_SCRIPT;

    public void selectObject(int obj) {
        selectedObject = objects[obj];
        addObjectToScript();
    }


    public void addScriptButton(int scr) {
        // se lo script c'è già non fare niente
        if (selectedScript == scr) return;

        // rimuovi lo script precedente
        removeScript(selectedScript);

        // aggiungi lo script
        selectedScript = scr;
        addScript(selectedScript);
        addObjectToScript();
    }


    private void addScript(int scr) {
        switch(scr) {
            case PLACE_ON_PLANE:
                this.gameObject.AddComponent<PlaceOnPlane>();
                break;
            case PLACE_MULTIPLE_OBJECTS:
                this.gameObject.AddComponent<PlaceMultipleObjects>();
                break;
            case CAST_RAY_ON_CLICK:
                this.gameObject.AddComponent<CastRayOnClick>();
                break;
            default:
                break;
        }
    }

    private void removeScript(int scr) {
        switch(scr) {
            case PLACE_ON_PLANE:
                Destroy(this.gameObject.GetComponent<PlaceOnPlane>());
                break;
            case PLACE_MULTIPLE_OBJECTS:
                Destroy(this.gameObject.GetComponent<PlaceMultipleObjects>());
                break;
            case CAST_RAY_ON_CLICK:
                Destroy(this.gameObject.GetComponent<CastRayOnClick>());
                break;
            default:
                break;
        }
    }



    private void addObjectToScript() {
        // if script or object are missing return
        if (selectedScript == NO_SCRIPT || !selectedObject) return;

        else if (selectedScript == PLACE_ON_PLANE) {
            PlaceOnPlane scr = this.gameObject.GetComponent<PlaceOnPlane>();
            scr.setPlacedPrefab(selectedObject);
        }

        else if (selectedScript == PLACE_MULTIPLE_OBJECTS) {
            PlaceMultipleObjects scr = this.gameObject.GetComponent<PlaceMultipleObjects>();
            scr.setPlacedPrefab(selectedObject);
        }
        return;
    }
}
