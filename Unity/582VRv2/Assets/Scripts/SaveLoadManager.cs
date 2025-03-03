using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class ObjectPositionData
{
    public string objectName; //Variable Intialization
    public float posX, posY, posZ; //Variable Intialization

    public ObjectPositionData(Transform transform)
    {
        objectName = transform.name; // Identify by object name
        posX = transform.position.x; //Assigning x
        posY = transform.position.y; //Assigning y
        posZ = transform.position.z; //Assigning z
    }

    public Vector3 GetPosition() //Function for translating our above data x,y, and z positions into a vector3
    {
        return new Vector3(posX, posY, posZ); //Returning vector3 with x, y , z
    }
}

[System.Serializable]
public class ObjectPositionList
{
    public List<ObjectPositionData> objects = new List<ObjectPositionData>(); //List of all saveable object data
}

public class SaveLoadManager : MonoBehaviour
{
    private string savePath; //File path thats generated for save file initialization

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "object_positions.json"); //File path thats generated for save file, using .json
    }

    public void SavePositions()
    {
        ObjectPositionList positionList = new ObjectPositionList(); //Init new list for storing
        SaveableObject[] saveableObjects = FindObjectsOfType<SaveableObject>(); //Finding all objects with the saveableobject script

        foreach (SaveableObject saveable in saveableObjects)
        {
            if (saveable.isSaveable) // Check if saving is enabled(boolean is true)
            {
                positionList.objects.Add(new ObjectPositionData(saveable.transform)); //Add position data of that object
            }
        }

        string json = JsonUtility.ToJson(positionList, true); //Translates to json
        File.WriteAllText(savePath, json); //Writes file 
        Debug.Log($"Positions Saved to: {savePath}"); //Debugging statement
    }

    public void LoadPositions()
    {
        if (File.Exists(savePath)) //If we have a save file
        {
            string json = File.ReadAllText(savePath); //Read the file
            ObjectPositionList positionList = JsonUtility.FromJson<ObjectPositionList>(json); //Translate back to our list

            foreach (ObjectPositionData data in positionList.objects) //For each object we saved earlier
            {
                GameObject obj = GameObject.Find(data.objectName); //Find that object in the game
                if (obj && obj.TryGetComponent(out SaveableObject saveable) && saveable.isSaveable) //Check if obj is valid
                {
                    obj.transform.position = data.GetPosition(); //Move the object to the saved position
                }
                else
                {
                    Debug.LogWarning($"Object '{data.objectName}' not found or not saveable."); //Debugging statement
                }
            }

            Debug.Log("Positions Loaded!"); //Debugging statement
        }
        else
        {
            Debug.LogWarning("Save file not found."); //Debugging statement
        }
    }
}
