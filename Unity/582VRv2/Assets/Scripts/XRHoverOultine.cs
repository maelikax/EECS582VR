using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRHoverOutline : MonoBehaviour
{
    private Outline outline; //Oultine variable
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;  //Grab interactable variable

    void Start()
    {
        outline = GetComponent<Outline>(); //Get outline component 
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>(); //Get grab interactable component

        grabInteractable.hoverEntered.AddListener(OnHover);//Listener for OnHover
        grabInteractable.hoverExited.AddListener(OnHoverExit);//Listener for OnHoverExit
        grabInteractable.selectEntered.AddListener(OnGrab);//Listener for OnGrab
        grabInteractable.selectExited.AddListener(OnRelease);//Listener for OnRelease
    }

    private void OnHover(HoverEnterEventArgs args)
    {
        outline.enabled = true; //Enable outline when hovered
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        outline.enabled = false; //Disable outline when no longer hovered
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        outline.OutlineColor = Color.blue; // Change color when grabbed(currently disabled)
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        outline.OutlineColor = Color.green; // Restore hover color
    }
}
