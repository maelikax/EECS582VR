using UnityEngine;

public class HUDLookAtPlayer : MonoBehaviour
{
    public Transform playerCamera; // Assign XR Camera (Main Camera in XR Origin)

    void Update()
    {
        if (playerCamera != null)
        {
            transform.LookAt(playerCamera); // Make the HUD face the player
            transform.Rotate(0, 180, 0);  // Flip to face correctly
        }
    }
}
