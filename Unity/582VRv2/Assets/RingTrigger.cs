using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player") || other.CompareTag("Drone"))
        {
            triggered = true;
            FindObjectOfType<RingManager>().ActivateNextRing();
        }
    }
}

