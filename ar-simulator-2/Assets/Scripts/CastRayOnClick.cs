using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastRayOnClick : PressInputBase {

    protected override void Awake() {
        base.Awake();
    }

    protected override void OnPress(Vector3 position) {
        RaycastHit hit;
        int distance = 500;
        /*
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = position - origin;
        direction = Vector3.Normalize(direction);

        if (Physics.Raycast(origin, direction, out hit, distance)) {
            Debug.DrawRay(origin, direction * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else {
            Debug.DrawRay(origin, direction * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
        */

        Ray ray = Camera.main.ScreenPointToRay(position);
        
        if (Physics.Raycast(ray, out hit, distance)) {
            Debug.Log("Did Hit");

            // If the object that has been hit implements the ClickableObject interface, call its OnClick method
            ClickableObject clickScript = hit.collider.gameObject.GetComponent<ClickableObject>();
            if (clickScript) {
                clickScript.OnClick();
            }
        }
        else {
            Debug.Log("Did not Hit");
        }
    }

}
