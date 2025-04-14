using UnityEngine;
using TMPro;  

public class DroneHUD : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI altitudeText;
    public TextMeshProUGUI batteryText;

    public Rigidbody droneRigidbody;  
    public Transform droneTransform;  
    private float batteryLevel = 100f;  

    void Update()
    {
        // Update Speed (Magnitude of Velocity)
        speedText.text = "Speed: " + Mathf.Round(droneRigidbody.linearVelocity.magnitude) + " m/s";
        Debug.Log("Speed updated.");
        // Update Altitude
        altitudeText.text = "Altitude: " + Mathf.Round(droneTransform.position.y) + " m";
        Debug.Log("Altitude updated.");
        // Simulate Battery Drain (Example)
        batteryLevel -= Time.deltaTime * 0.1f;  
        batteryText.text = "Battery: " + Mathf.Round(batteryLevel) + "%";
    }
}
