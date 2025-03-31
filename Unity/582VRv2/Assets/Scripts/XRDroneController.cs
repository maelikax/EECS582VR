using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRDroneController : MonoBehaviour
{
    public InputActionProperty moveInput; // Joystick movement (Vector2)
    public InputActionProperty altitudeUpInput; // Input for moving up (trigger/grip)
    public InputActionProperty altitudeDownInput; // Input for moving down (trigger/grip)
    public InputActionProperty rotationInput; // Joystick rotation (Vector2)
    public float moveSpeed = 2.0f;
    public float verticalSpeed = 1.5f;
    public float rotationSpeed = 50f;

    private void Update()
    {
        MoveDrone();
        RotateDrone();
    }

    private void MoveDrone()
    {
        Vector2 moveVector = moveInput.action.ReadValue<Vector2>();
        float altitudeUp = altitudeUpInput.action.ReadValue<float>();
        float altitudeDown = altitudeDownInput.action.ReadValue<float>();

        // Convert joystick input into movement directions
        Vector3 forwardMovement = transform.forward * moveVector.y * moveSpeed * Time.deltaTime;
        Vector3 sidewaysMovement = transform.right * moveVector.x * moveSpeed * Time.deltaTime;
        Vector3 verticalMovement = Vector3.up * (altitudeUp - altitudeDown) * verticalSpeed * Time.deltaTime;

        // Apply movement
        transform.position += forwardMovement + sidewaysMovement + verticalMovement;
    }

    private void RotateDrone()
    {
        Vector2 rotationVector = rotationInput.action.ReadValue<Vector2>();
        float rotationAmount = rotationVector.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
