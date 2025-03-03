using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single); //
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
