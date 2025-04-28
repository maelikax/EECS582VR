using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Import TextMeshPro namespace

public class HUDInformation : MonoBehaviour
{
    public XRDroneController droneController;
    public TextMeshProUGUI speedText;  // Reference to TextMeshProUGUI for speed
    public TextMeshProUGUI altitudeText;  // Reference to TextMeshProUGUI for altitude


    private void Update()
    {
        if (droneController != null)
        {
            speedText.text = $"Speed: {droneController.CurrentSpeed:F2} m/s";
            altitudeText.text = $"Altitude: {droneController.CurrentAltitude:F2} m";
        }
    }
}
