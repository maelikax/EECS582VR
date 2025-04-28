using UnityEngine;

public class RingManager : MonoBehaviour
{
    public GameObject[] rings;
    public Material activeMaterial;
    public Material inactiveMaterial;

    private int currentIndex = 0;

    void Start()
    {
        UpdateRingMaterials();
    }

    public void ActivateNextRing()
    {
        currentIndex++;

        if (currentIndex < rings.Length)
        {
            UpdateRingMaterials();
        }
        else
        {
            Debug.Log("✅ All rings completed!");
        }
    }

    void UpdateRingMaterials()
    {
        for (int i = 0; i < rings.Length; i++)
        {
            Renderer r = rings[i].GetComponent<Renderer>();
            r.material = (i == currentIndex) ? activeMaterial : inactiveMaterial;
        }
    }
}
