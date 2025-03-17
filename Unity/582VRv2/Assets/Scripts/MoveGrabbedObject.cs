using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;  // Required for FirstOrDefault()

public class MoveGrabbedObject : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor rightHandInteractor;  // Assign your Right Hand Near-Far Interactor
    public InputActionProperty moveCloserAction;   // A Button (Primary Button)
    public InputActionProperty moveFurtherAction;  // B Button (Secondary Button)
    public float moveSpeed = 0.1f;  // Speed of movement

    private Transform grabbedObject;  // Currently grabbed object
    private Rigidbody grabbedRigidbody;  // The Rigidbody of the grabbed object (if applicable)
    private bool isMoving = false; // Flag to track if we are moving the object

    private void Update()
    {
        UpdateGrabbedObject();

        if (grabbedObject != null && isMoving) //If gameboject exists and isMoving
        {
            // Move the grabbed object based on input
            if (moveCloserAction.action.IsPressed())
            {
                Debug.Log("A button held - Moving closer");
                grabbedObject.position += transform.forward * moveSpeed; //Move the object toward the player
            }
            if (moveFurtherAction.action.IsPressed())
            {
                Debug.Log("B button held - Moving further");
                grabbedObject.position -= transform.forward * moveSpeed; //Move the object away from the player
            }
        }
    }

    private void UpdateGrabbedObject()
    {
        // Check if the interactor has selected any object
        if (rightHandInteractor != null && rightHandInteractor.interactablesSelected.Count > 0)
        {
            var selectedInteractable = rightHandInteractor.interactablesSelected.FirstOrDefault(); //Assign the selected object to variable
            grabbedObject = selectedInteractable?.transform; //Selected interactable position(which will be what we are changing)

            if (grabbedObject != null) //We have grabbed an object
            {
                grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>(); 

                // Temporarily disable physics while manually moving
                if (grabbedRigidbody != null)
                {
                    grabbedRigidbody.isKinematic = true; //Disable physics
                }

                isMoving = true;//Object now is moving
            }
        }
        else
        {
            // Restore physics and reset variables when no object is grabbed
            if (grabbedRigidbody != null)
            {
                grabbedRigidbody.isKinematic = false; //Enable physics again
            }

            grabbedObject = null;//grabbedObject reset
            grabbedRigidbody = null; //Rigidbody reset
            isMoving = false; //False
        }
    }
}
