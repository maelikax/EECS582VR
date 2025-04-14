using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Required for TextMeshPro support

public class PartsPlacedTracker : MonoBehaviour
{
    public TextMeshProUGUI placedPartsText; // Reference to UI text
    private int placedPartsCount = 0; // Counter for placed parts
    public int totalPartCount = 10; //Total parts for machine
    public Slider progressBar;  // Reference to the Slider component (progress bar)
    public Text progressText;    // Reference to the Text component that shows percentage 
    public GameObject[] nextPartsToEnable; // Parts to enable once the required parts are placed
    // Method to increase count when an object is placed
    public void IncreasePlacedParts()
    {   
        placedPartsCount++; //Increase
        EnableNextParts();
        UpdateUI();
    }

    // Method to decrease count (optional, if objects can be removed)
    public void DecreasePlacedParts()
    {
        placedPartsCount--; //Decrease
        UpdateUI(); //UpdateUI
    }
    private void EnableNextParts()
    {
        // You can define which parts to enable after certain steps. Example:
        if (placedPartsCount == 2 && nextPartsToEnable.Length > 0) //If base and cap get placed. 
        {
            nextPartsToEnable[0].SetActive(true);//Enable motor
            nextPartsToEnable[1].SetActive(true);//Enable motor
            nextPartsToEnable[2].SetActive(true);//Enable motor
            nextPartsToEnable[3].SetActive(true);//Enable motor
        }
        if (placedPartsCount == 6 && nextPartsToEnable.Length > 1) //If base/cap and also motors are placed
        {
            nextPartsToEnable[4].SetActive(true);//Enable cap for motors
            nextPartsToEnable[5].SetActive(true); //Enable base for motors
            nextPartsToEnable[6].SetActive(true); //Enable propeller
            nextPartsToEnable[7].SetActive(true); //Enable propeller
            nextPartsToEnable[8].SetActive(true); //Enable propeller
            nextPartsToEnable[9].SetActive(true); //Enable propeller
        }
        // Add more conditions if you have more parts and actions to trigger
    }
    // Update the UI with the current count
    private void UpdateUI()
    {
        if (placedPartsCount == 2)
        {
          placedPartsText.text = "placeholder for when user has base/cap attached"; //Update text sign       
        }
        if (placedPartsCount == 6)
        {
          placedPartsText.text = "placeholder for when user has motors attached"; //Update text sign       
        }
        if (placedPartsCount == totalPartCount)
        {
          placedPartsText.text = "placeholder for when user has all parts attached"; //Update text sign       
        }
        
        progressBar.value = placedPartsCount; //Update progressBar
        progressText.text = Mathf.FloorToInt((float)placedPartsCount / totalPartCount * 100) + "%"; //UpdateprogressBar
    }
}
