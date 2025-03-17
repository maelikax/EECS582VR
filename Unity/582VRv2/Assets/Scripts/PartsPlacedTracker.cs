using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Required for TextMeshPro support

public class PartsPlacedTracker : MonoBehaviour
{
    public TextMeshProUGUI placedPartsText; // Reference to UI text
    private int placedPartsCount = 0; // Counter for placed parts
    public int totalPartCount = 4; //Total parts for machine
    public Slider progressBar;  // Reference to the Slider component (progress bar)
    public Text progressText;    // Reference to the Text component that shows percentage 

    // Method to increase count when an object is placed
    public void IncreasePlacedParts()
    {
        placedPartsCount++; //Increase
        UpdateUI(); //UpdateUI
    }

    // Method to decrease count (optional, if objects can be removed)
    public void DecreasePlacedParts()
    {
        placedPartsCount--; //Decrease
        UpdateUI(); //UpdateUI
    }

    // Update the UI with the current count
    private void UpdateUI()
    {
        placedPartsText.text = "Parts Placed: " + placedPartsCount + " out of " + totalPartCount; //Update text sign
        progressBar.value = placedPartsCount; //Update progressBar
        progressText.text = Mathf.FloorToInt((float)placedPartsCount / totalPartCount * 100) + "%"; //UpdateprogressBar
    }
}
