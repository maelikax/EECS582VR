using UnityEngine;
using UnityEngine.UI;

public class SaveLoadUI : MonoBehaviour
{
    public Button saveButton; //Savebutton init
    public Button loadButton; //Loadbutton init
    private SaveLoadManager saveLoadManager; //Init(basically importing from a empty GameObject) the SaveLoadManager script

    private void Start()
    {
        saveLoadManager = FindObjectOfType<SaveLoadManager>(); //Calling function from SaveLoadManager

        if (saveButton != null)
            saveButton.onClick.AddListener(SaveGame); //Calling SaveGame

        if (loadButton != null)
            loadButton.onClick.AddListener(LoadGame); //Calling LoadGame
    }

    private void SaveGame()
    {
        saveLoadManager.SavePositions(); //Calling our function from SaveLoadManager
        Debug.Log("Game Saved via Button!");
    }

    private void LoadGame()
    {
        saveLoadManager.LoadPositions(); //Calling our function from SaveLoadManager
        Debug.Log("Game Loaded via Button!");
    }
}
