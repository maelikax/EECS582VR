using UnityEngine;


public class SnapSlot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block")) // Check if it's a block
        {
            other.transform.position = transform.position; // Snap position
            other.transform.rotation = transform.rotation; // Align rotation
            other.GetComponent<Rigidbody>().isKinematic = true; // Lock in place
            
            UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (grabInteractable != null){
                grabInteractable.enabled = false;
            }
        }
    }
}
