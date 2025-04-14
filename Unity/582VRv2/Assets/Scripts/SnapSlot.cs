using UnityEngine;
using System.Collections;

public class SnapSlot : MonoBehaviour
{
    public string targetTag = ""; //Control what tag we look for
    public GameObject transparentBoxPrefab; //Control which prefab we use for our transparentBox
    public float snapSpeed = 5f; // Control the snap speed
    private PartsPlacedTracker tracker;//Variable for PartsPlacedTracker
    private GameObject transparentBox;//Variable for creating the actual GameObject for transparentBox
    private bool isOccupied = false; // Prevent double counting

    public AudioSource buildSound; 
    private void Start()
    {   
        tracker = FindObjectOfType<PartsPlacedTracker>();
        if (transparentBoxPrefab != null) //If we don't have a transparentBox already spawned in
        {
            transparentBox = Instantiate(transparentBoxPrefab, transform.position, transform.rotation); //Spawn in the transparentBox
            transparentBox.transform.SetParent(transform);//Set it as a parent of our original object
        }
        else
        {
            Debug.LogWarning("Transparent box prefab is not assigned in the Inspector."); //Debug statement
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isOccupied) return; // Prevent multiple triggers if object gets read as entering multiple times

        if (other.CompareTag(targetTag)) //If we see the targetTag
        {
            isOccupied = true; // Mark as occupied
            StartCoroutine(SmoothSnap(other.transform)); // Start the smooth snap

            Rigidbody rb = other.GetComponent<Rigidbody>(); //Get rigidbody component from object we collided with
            if (rb != null)
            {
                rb.isKinematic = true; // Disable physics
            }

            var grabInteractable = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>(); //Get XR Grabbable component of object we collide with
            if (grabInteractable != null) //If enabled
            {
                grabInteractable.enabled = false; //Disable being grabbable
            }
            var isPlaced = other.GetComponent<MarkAsPlaced>();
            if(isPlaced != null)
            {
                isPlaced.isPlaced= true; 
            }

            if (transparentBox != null) //If transparentbox is spawned in
            {
                transparentBox.SetActive(false); //Despawn it 
            }

            tracker.IncreasePlacedParts(); // Increase count only once
        }
    }

    private IEnumerator SmoothSnap(Transform target)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = target.position;
        Quaternion startRotation = target.rotation;
        Vector3 endPosition = transform.position;
        Quaternion endRotation = transform.rotation;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * snapSpeed;
            target.position = Vector3.Lerp(startPosition, endPosition, elapsedTime);
            target.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime);
            yield return null;
        }

    // Ensure final position is exact   
        target.position = endPosition;
        target.rotation = endRotation;
        target.SetParent(transform); // Parent to SnapSlot

        Rigidbody rb = target.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; 
            rb.useGravity = false; 
            rb.linearVelocity = Vector3.zero; 
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void ResetSnapSlot() //Helper function for resetting SnapSlots for potential use later. 
    {
        if (transparentBox != null)//If transparentbox is spawned in
        {
            transparentBox.SetActive(true); //Despawn it
        }

        isOccupied = false; //Set to false 
        
    }
    
}
