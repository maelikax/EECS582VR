using UnityEngine;

public class PulseEmission : MonoBehaviour
{
    public Material material;
    public Color baseEmissionColor = Color.green;
    public float pulseSpeed = 2.0f; // How fast it pulses
    public float pulseStrength = 2.0f; // How strong the pulse is

    void Update()
    {
        float pulse = (Mathf.Sin(Time.time * pulseSpeed) + 1.0f) / 2.0f; // goes from 0 to 1
        Color pulsingColor = baseEmissionColor * Mathf.Lerp(0.5f, pulseStrength, pulse);
        material.SetColor("_EmissionColor", pulsingColor);
    }
}
