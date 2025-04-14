using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single); //Loading MainGame scene
    }

    public void TestingPlace()
    {
        SceneManager.LoadScene("testingscenev2", LoadSceneMode.Single); //Loading MainGame scene
    }
     public void MiniGame()
    {
        SceneManager.LoadScene("minigame", LoadSceneMode.Single); //Loading MainGame scene
    }
    public void QuitGame()
    {
        Application.Quit(); //Quits application if QuitGame is called
    }
}
