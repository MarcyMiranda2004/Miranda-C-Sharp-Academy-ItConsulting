using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider sliderVolume;
    public float volume;
    public TextMeshProUGUI volumeText;

    void Start()
    {
        sliderVolume.onValueChanged.AddListener(ModificaVolume);
    }


    void ModificaVolume(float value)
    {
        volume = value;
        volumeText.text = $"Volume: {volume:F2}";
    }
}