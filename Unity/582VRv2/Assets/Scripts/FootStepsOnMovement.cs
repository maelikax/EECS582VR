using UnityEngine;

public class FootstepsOnMovement : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource
    public AudioClip[] footstepSounds; // Array to store footstep sounds
    public float stepInterval = 0.5f; // Time between steps
    public float movementThreshold = 0.1f; // Minimum movement speed to trigger footsteps
    public float movementSpeedThreshold = 0.5f; // Threshold speed for when to trigger footsteps

    private Vector3 lastPosition; // Store the previous position of the XR Rig
    private float stepTimer; // Timer to control step interval

    private void Start()
    {
        // Initialize last position
        lastPosition = transform.position;
        stepTimer = stepInterval;
    }

    private void Update()
    {
        // Check if the player is moving
        float movementDistance = Vector3.Distance(transform.position, lastPosition);
        
        if (movementDistance > movementThreshold)
        {
            stepTimer -= Time.deltaTime;

            // If it's time for a step, play the footstep sound
            if (stepTimer <= 0f)
            {
                PlayRandomFootstepSound();
                stepTimer = stepInterval;
            }
        }

        // Update last position for next frame
        lastPosition = transform.position;
    }

    private void PlayRandomFootstepSound()
    {
        // Check if the footstep sounds array is not empty
        if (footstepSounds != null && footstepSounds.Length > 0 && audioSource != null)
        {
            // Choose a random index from the array
            int randomIndex = Random.Range(0, footstepSounds.Length);
            AudioClip selectedFootstep = footstepSounds[randomIndex];

            // Play the selected random footstep sound
            audioSource.PlayOneShot(selectedFootstep);
        }
    }
}
