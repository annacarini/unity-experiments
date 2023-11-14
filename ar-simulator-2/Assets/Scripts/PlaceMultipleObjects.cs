using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;


[RequireComponent(typeof(ARRaycastManager))]

public class PlaceMultipleObjects : PressInputBase {

    [SerializeField]  // -> forces Unity to serialize the private field below
    GameObject placedPrefab;

    GameObject spawnedObject;   // instantiated prefab

    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    protected override void Awake() {
        base.Awake();
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    protected override void OnPress(Vector3 position) {
        // Check if the raycast hits any trackables
        if (aRRaycastManager.Raycast(position, hits, TrackableType.PlaneWithinPolygon)) {

            // Instantiate object
            var hitPose = hits[0].pose;
            spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);

            // To make the spawned object always look at the camera
            Vector3 lookPos = Camera.main.transform.position - spawnedObject.transform.position;
            lookPos.y = 0;
            spawnedObject.transform.rotation = Quaternion.LookRotation(lookPos);
        }
    }
}
