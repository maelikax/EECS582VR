using UnityEngine;
using UnityEngine.XR;

public class XRRecenter : MonoBehaviour
{
    void Start()
    {
        RecenterRig();
    }

    public void RecenterRig()
    {
        // Get the rotation offset of the headset
        Quaternion headsetRotation = InputTracking.GetLocalRotation(XRNode.Head);
        
        // Only rotate around the Y-axis to match the correct forward direction
        float yRotation = -headsetRotation.eulerAngles.y;
        
        // Apply the rotation offset to the XR Rig
        transform.Rotate(0, yRotation, 0, Space.World);
    }
}
