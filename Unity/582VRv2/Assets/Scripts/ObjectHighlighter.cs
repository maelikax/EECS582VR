using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    // Exposed light properties
    public float lightIntensity = 2f; // Intensity of the light
    public float lightRange = 10f;    // Range of the light
    public Color lightColor = Color.yellow; // Color of the light
    public Vector3 lightOffset = new Vector3(0, 5, 0); // Offset for the light position

    void Start()
    {
        Debug.Log("Spawning Light...");
        SpawnLight();
    }

    void SpawnLight()
    {
        // Create a new GameObject for the light
        GameObject lightGameObject = new GameObject("HighlightLight");

        // Add a Light component to this new GameObject
        Light lightInstance = lightGameObject.AddComponent<Light>();

        // Set the type of light (you can change this to Point, Spot, etc.)
        lightInstance.type = LightType.Point;  // For example, a Point light
        lightInstance.intensity = lightIntensity; // Set intensity from the public variable
        lightInstance.range = lightRange; // Set range from the public variable
        lightInstance.color = lightColor; // Set color from the public variable

        // Set the light's position to the object's position + the offset
        lightInstance.transform.position = transform.position + lightOffset;

        // Make the light a child of the object the script is attached to
        lightInstance.transform.SetParent(transform);

        // Ensure the light is active
        lightInstance.gameObject.SetActive(true);

        // Log the position of the spawned light in world space
        Debug.Log($"Light spawned at position: {lightInstance.transform.position}");
    }
}
