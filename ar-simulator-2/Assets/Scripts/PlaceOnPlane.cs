using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;


[RequireComponent(typeof(ARRaycastManager))]

public class PlaceOnPlane : PressInputBase {

    [SerializeField]  // -> forces Unity to serialize the private field below
    GameObject placedPrefab;

    GameObject spawnedObject;   // instantiated prefab

    bool isPressed;

    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    protected override void Awake() {
        base.Awake();
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }


    // Update is called once per frame
    void Update() {
        
        if (Pointer.current == null || isPressed == false) {
            return;
        }

        // Store the current touch position
        var touchPosition = Pointer.current.position.ReadValue();

        // Check if the raycast hits any trackables
        if (aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon)) {
            var hitPose = hits[0].pose;

            // Check if there is already a spawned object. If there isn't, instantiate the prefab
            if (spawnedObject == null) {
                spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            }
            // Else change the spawned object's position and rotation to the touch position
            else {
                spawnedObject.transform.position = hitPose.position;
                spawnedObject.transform.rotation = hitPose.rotation;
            }

            // To make the spawned object always look at the camera
            Vector3 lookPos = Camera.main.transform.position - spawnedObject.transform.position;
            lookPos.y = 0;
            spawnedObject.transform.rotation = Quaternion.LookRotation(lookPos);
        }
    }

    protected override void OnPress(Vector3 position) {
        isPressed = true;
    }

    protected override void OnPressCancel() {
        isPressed = false;
    }
}
