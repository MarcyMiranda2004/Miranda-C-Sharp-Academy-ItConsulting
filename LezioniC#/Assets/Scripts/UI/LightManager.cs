using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{
    [Header("Riferimenti")]
    public Slider sliderLight;
    public Light light;

    void Start()
    {
        sliderLight.onValueChanged.AddListener(ModificaLight);
    }

    void ModificaLight(float value)
    {
        light.intensity = value;
    }
}