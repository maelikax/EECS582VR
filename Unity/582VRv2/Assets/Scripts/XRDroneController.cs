using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRDroneController : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionProperty moveInput;            // Joystick movement (Vector2)
    public InputActionProperty altitudeUpInput;      // Input for moving up (trigger/grip)
    public InputActionProperty altitudeDownInput;    // Input for moving down (trigger/grip)
    public InputActionProperty rotationInput;        // Joystick rotation (Vector2)

    [Header("Movement Settings")]
    public float moveSpeed = 2.0f;
    public float verticalSpeed = 1.5f;
    public float rotationSpeed = 50f;
    public float accelerationTime = 0.3f;
    public float dragCoefficient = 0.95f;

    [Header("Audio")]
    public AudioSource engineAudioSource;   // Drag your engine sound AudioSource here
    public AudioSource hoverAudioSource;    // Drag your hover sound AudioSource here
    public float engineMinPitch = 0.9f;
    public float engineMaxPitch = 2.0f;
    public float audioSmoothing = 3f;

    private Vector3 currentVelocity = Vector3.zero;
    private Vector3 velocitySmoothDamp = Vector3.zero;

    private void Start()
    {
        if (engineAudioSource != null && !engineAudioSource.isPlaying)
            engineAudioSource.Play();

        if (hoverAudioSource != null && !hoverAudioSource.isPlaying)
            hoverAudioSource.Play();
    }

    private void Update()
    {
        MoveDrone();
        RotateDrone();
        UpdateAudio();
    }

    private void MoveDrone()
    {
        Vector2 moveVector = moveInput.action.ReadValue<Vector2>();
        float altitudeUp = altitudeUpInput.action.ReadValue<float>();
        float altitudeDown = altitudeDownInput.action.ReadValue<float>();

        Vector3 forwardMovement = transform.forward * moveVector.y * moveSpeed;
        Vector3 sidewaysMovement = transform.right * moveVector.x * moveSpeed;
        Vector3 verticalMovement = Vector3.up * (altitudeUp - altitudeDown) * verticalSpeed;

        Vector3 targetVelocity = forwardMovement + sidewaysMovement + verticalMovement;

        // Smooth acceleration toward target velocity
        currentVelocity = Vector3.SmoothDamp(currentVelocity, targetVelocity, ref velocitySmoothDamp, accelerationTime);

        // Apply drag when idle
        if (targetVelocity.magnitude < 0.01f)
            currentVelocity *= dragCoefficient;

        // Move the drone
        transform.position += currentVelocity * Time.deltaTime;
    }

    private void RotateDrone()
    {
        Vector2 rotationVector = rotationInput.action.ReadValue<Vector2>();
        float rotationAmount = rotationVector.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }

    private void UpdateAudio()
    {
        float speedPercent = Mathf.Clamp01(currentVelocity.magnitude / moveSpeed);

        if (engineAudioSource != null)
        {
            float targetPitch = Mathf.Lerp(engineMinPitch, engineMaxPitch, speedPercent);
            float targetVolume = speedPercent;

            engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, targetPitch, Time.deltaTime * audioSmoothing);
            engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, targetVolume, Time.deltaTime * audioSmoothing);
        }

        if (hoverAudioSource != null)
        {
            float targetHoverVolume = Mathf.Clamp01(1f - speedPercent);
            hoverAudioSource.volume = Mathf.Lerp(hoverAudioSource.volume, targetHoverVolume, Time.deltaTime * audioSmoothing);
        }
    }
}
