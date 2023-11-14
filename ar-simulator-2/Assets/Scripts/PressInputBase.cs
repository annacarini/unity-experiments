using UnityEngine;
using UnityEngine.InputSystem;

public class PressInputBase : MonoBehaviour {

    protected InputAction clickAction; // an action is an object with a collection of bindings that trigger the action

    protected virtual void Awake() {

        // Create a new input
        clickAction = new InputAction("click", binding: "<Pointer>/press");

        // Callback when the click starts
        clickAction.started += context => {
            if (context.control.device is Pointer device) {
                OnPressBegan(device.position.ReadValue());
            }
        };

        // Callback for the click
        clickAction.performed += context => {
            if (context.control.device is Pointer device) {
                OnPress(device.position.ReadValue());
            }
        };

        // Callback for click canceled
        clickAction.canceled += _ => OnPressCancel();
    }

    protected virtual void OnEnable() {
        clickAction.Enable();   // enable the action so that it listens/reacts to input
    }

    protected virtual void OnDisable() {
        clickAction.Disable();
    }

     protected virtual void OnDestroy() {
        clickAction.Dispose();
    }

    protected virtual void OnPress(Vector3 position) {}

    protected virtual void OnPressBegan(Vector3 position) {}

    protected virtual void OnPressCancel() {}

}
