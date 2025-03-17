using UnityEngine;
using UnityEngine.InputSystem;


public class DynamicGrabDistance : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable; // XR grab component
    public Transform attachTransform; // The attach point for grabbing
    public InputActionProperty moveCloserAction; // Input for moving object closer
    public InputActionProperty moveFartherAction; // Input for moving object farther
    public float adjustSpeed = 0.05f; // Speed of movement

    private void OnEnable()
    {
        moveCloserAction.action.Enable();
        moveFartherAction.action.Enable();
    }

    private void OnDisable()
    {
        moveCloserAction.action.Disable();
        moveFartherAction.action.Disable();
    }

    void Update()
    {
        if (grabInteractable.isSelected) // Only adjust if the object is grabbed
        {
            if (moveCloserAction.action.WasPressedThisFrame())
                attachTransform.localPosition += Vector3.forward * adjustSpeed;

            if (moveFartherAction.action.WasPressedThisFrame())
                attachTransform.localPosition -= Vector3.forward * adjustSpeed;
        }
    }
}
