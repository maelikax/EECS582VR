using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ButtonVisualFeedback : MonoBehaviour
{
    public InputActionReference aButtonAction;
    public InputActionReference bButtonAction;
    public TextMeshProUGUI statusText;

    void OnEnable()
    {
        aButtonAction.action.performed += OnAButtonPressed;
        bButtonAction.action.performed += OnBButtonPressed;
    }

    void OnDisable()
    {
        aButtonAction.action.performed -= OnAButtonPressed;
        bButtonAction.action.performed -= OnBButtonPressed;
    }

    private void OnAButtonPressed(InputAction.CallbackContext context)
    {
        statusText.text = "A Button Pressed";
    }

    private void OnBButtonPressed(InputAction.CallbackContext context)
    {
        statusText.text = "B Button Pressed";
    }
}
