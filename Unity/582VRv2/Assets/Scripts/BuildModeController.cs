using UnityEngine;
using UnityEngine.InputSystem;

public class BuildModeController : MonoBehaviour
{
    public Transform buildModePosition;  // Position above the workbench
    public GameObject xrRig; // The entire XR Rig (player's camera and controllers)
    public InputActionProperty toggleBuildModeAction;  // The input action for toggling build mode

    private bool isInBuildMode = false;

    // Camera rotation to look downward in Build Mode
    public Vector3 buildModeLookRotation = new Vector3(90f, 0f, 0f); // X: 90 degrees (looking down), Y: 0 degrees, Z: 0 degrees

    void Update()
    {
        // Check if the build mode toggle button is pressed
        if (toggleBuildModeAction.action.WasPressedThisFrame())
        {
            ToggleBuildMode();
        }
    }

    void ToggleBuildMode()
    {
        isInBuildMode = !isInBuildMode;

        if (isInBuildMode)
        {
            // Move the player (XR Rig) to the build mode position (above the workbench)
            MoveToBuildModePosition();
        }
        else
        {
            // Move the player (XR Rig) back to the original position (or wherever you want them to return)
            ResetPosition();
        }
    }

    void MoveToBuildModePosition()
    {
        // Teleport the XR Rig to the build mode position
        xrRig.transform.position = buildModePosition.position;

        // Set the XR Rig's rotation to look downwards
        xrRig.transform.rotation = Quaternion.Euler(buildModeLookRotation);

        // Optionally, disable or modify interactions in build mode (e.g., stop movement controls)
        DisableMovementControls();
    }

    void ResetPosition()
    {
        // Reset player (XR Rig) position back to normal (or wherever you want)
        // You can store the original position if necessary or hard-code a position here
        xrRig.transform.position = new Vector3(0, 1, 0);  // Example: reset to the original position
        xrRig.transform.rotation = Quaternion.identity;

        // Optionally, enable movement controls again
        EnableMovementControls();
    }

    void DisableMovementControls()
    {
        // Disable movement control if applicable (e.g., disable teleportation or walking)
        var teleportation = xrRig.GetComponentInChildren<UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationProvider>();
        if (teleportation)
        {
            teleportation.enabled = false;
        }

        // Disable other movement systems if you have any (e.g., continuous movement or teleportation)
    }

    void EnableMovementControls()
    {
        // Re-enable movement controls if applicable
        var teleportation = xrRig.GetComponentInChildren<UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationProvider>();
        if (teleportation)
        {
            teleportation.enabled = true;
        }

        // Enable other movement systems again if you have them
    }
}
