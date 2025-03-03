using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class QuadcopterPartsDataManager : MonoBehaviour
{
    public Transform partTransfrom;
    public void SaveGame()  // User can save game progress
    {
        QuadcopterPartsData quadcopterPartsData = new QuadcopterPartsData();  // Loads QuadcopterPartsData into the script
        quadcopterPartsData.position = new float[] {partTransfrom.position.x, partTransfrom.position.y, partTransfrom.position.z};   //Gets the last saved position of the quadcopter part

        string json = JsonUtility.ToJson(quadcopterPartsData);  // Able to load everything into a json file
        string path = Application.persistentDataPath + "/quadcopterpartsData.json";   // Path to where the data is located
        System.IO.File.WriteAllText(path, json);    //

        Debug.LogWarning("Game successfully saved, file created at: " + path);  // If game was actuallly saved
    }

    public void LoadGame()  // Program is able to load the game from when the player last saved
    {
        string path = Application.persistentDataPath + "/quadcopterpartsData.json"; // Path to json file created in SaveGame()
        if (File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path); // Read all of the text from the path file
            QuadcopterPartsData loadedData = JsonUtility.FromJson<QuadcopterPartsData>(json);   // Loads data from Json file

            // Update quadcopter part's position
            partTransfrom.position = new Vector3(loadedData.position[0], loadedData.position[1], loadedData.position[2]);    // Vector (x, y, z) position of part
            Vector3 loadedPosition = new Vector3(loadedData.position[0], loadedData.position[1], loadedData.position[2]);

            // Load in last saved position/values from quadcopterpartsdata
            partTransfrom.position = loadedPosition;
        }
        else
        {
            Debug.LogWarning("WARNING: File not found.");   // If there's no file saved/found
        }
    }
}
