using UnityEngine;

public class SnapSlot : MonoBehaviour
{
    [SerializeField] private string targetTag = "";
    [SerializeField] private GameObject transparentBoxPrefab; // Transparent box prefab reference
    private GameObject transparentBox; // Instance of the transparent box

    private void Start()
    {
        // Check if the transparent box prefab is assigned
        if (transparentBoxPrefab != null)
        {
            // Instantiate the transparent box at the SnapSlot's position with the same size and rotation
            transparentBox = Instantiate(transparentBoxPrefab, transform.position, transform.rotation);
            
            // Set the transparent box to be a child of the SnapSlot for proper positioning
            transparentBox.transform.SetParent(transform);
        }
        else
        {
            Debug.LogWarning("Transparent box prefab is not assigned in the Inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag)) // Check if it's a block
        {
            other.transform.position = transform.position; // Snap position
            other.transform.rotation = transform.rotation; // Align rotation
            other.GetComponent<Rigidbody>().isKinematic = true; // Lock in place
            
            UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.enabled = false;
            }

            // Hide the transparent box
            if (transparentBox != null)
            {
                transparentBox.SetActive(false); // Or use transparentBox.GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
