using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene reloading

public class ResetLevel : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the current level
    }
}
