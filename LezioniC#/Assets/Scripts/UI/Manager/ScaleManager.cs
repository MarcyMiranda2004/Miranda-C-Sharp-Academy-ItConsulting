using UnityEngine;
using UnityEngine.UI;

public class Scalemanager : MonoBehaviour
{
    [Header("Riferimenti UI")]
    public Slider scalaSlider;
    public Button resetButton;
    public Button toggleSliderButton;

    [Header("Oggetto da Scalare")]
    public Transform oggetto3D;

    private bool sliderAttivo = true;

    void Start()
    {
        scalaSlider.value = oggetto3D.localScale.x;

        scalaSlider.onValueChanged.AddListener(AggiornaScala);
        resetButton.onClick.AddListener(ResetScala);
        toggleSliderButton.onClick.AddListener(ToggleSlider);
    }

    void AggiornaScala(float valore)
    {
        oggetto3D.localScale = Vector3.one * valore;
    }

    void ResetScala()
    {
        scalaSlider.value = 1f;
    }

    void ToggleSlider()
    {
        sliderAttivo = !sliderAttivo;
        scalaSlider.gameObject.SetActive(sliderAttivo);
        ResetScala();
    }
}
