using UnityEngine;

public class PulseEmissionOverride : MonoBehaviour
{
    [Header("Material Settings")]
    public Material overrideMaterial; // Material to override with
    private Material runtimeMaterial; // Runtime instance we modify
    private Material originalMaterial; // Backup of the original material

    [Header("Emission Settings")]
    public Color baseEmissionColor = Color.green;
    public float pulseSpeed = 2.0f;
    public float pulseStrength = 2.0f;

    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();

        if (objRenderer != null)
        {
            // Save original material
            originalMaterial = objRenderer.material;

            if (overrideMaterial != null)
            {
                // Create a new material instance so we don't modify shared assets
                runtimeMaterial = new Material(overrideMaterial);

                // Assign the runtime material
                objRenderer.material = runtimeMaterial;

                // Enable emission on it
                runtimeMaterial.EnableKeyword("_EMISSION");
            }
            else
            {
                Debug.LogWarning("PulseEmissionOverride: No override material assigned.");
            }
        }
        else
        {
            Debug.LogWarning("PulseEmissionOverride: No Renderer found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (runtimeMaterial != null)
        {
            float pulse = (Mathf.Sin(Time.time * pulseSpeed) + 1.0f) / 2.0f;
            Color pulsingColor = baseEmissionColor * Mathf.Lerp(0.5f, pulseStrength, pulse);
            runtimeMaterial.SetColor("_EmissionColor", pulsingColor);
        }
    }

    void OnDisable()
    {
        if (objRenderer != null && originalMaterial != null)
        {
            objRenderer.material = originalMaterial;
        }
    }
}
