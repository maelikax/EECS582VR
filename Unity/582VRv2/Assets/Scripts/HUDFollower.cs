using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
public class HUDFollower : MonoBehaviour
{
    public Transform cameraTransform;
    public float distance = 1.0f;
    public float heightOffset = 0.0f;
    public float followSpeed = 5.0f;

    void LateUpdate()
    {
        Vector3 targetPos = cameraTransform.position + cameraTransform.forward * distance;
        targetPos.y += heightOffset;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);

        // Look at camera (optional for fixed HUD)
        transform.LookAt(cameraTransform);
        transform.Rotate(0, 180f, 0); // So it's not backwards
    }
}
