using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PannelloManager : MonoBehaviour
{
    [Header("Riferimenti UI - Ess Toggle ")]
    public Toggle pannelloToggle;
    public GameObject pannello;
    public Button chiudiPannello;
    public TextMeshProUGUI pannelloStatusText;

    [Header("Riferimenti UI - Ess Toggle 2")]
    public Toggle textTog;
    public Toggle imgTog;
    public Toggle btnTog;
    public TextMeshProUGUI pnlText;
    public RawImage pnlImg;
    public Button pnButton;

    [Header("Riferimenti UI - Ess Dropdown 1")]
    public TMP_Dropdown colorDropdown;
    private Image pannelloImage;

    [Header("Riferimenti UI - Ess Dropdown 2")]
    public TMP_Dropdown difficoltaDropdown;
    public TextMeshProUGUI difficoltaText;

    [Header("Riferimenti UI - Ess Dropdown 3")]
    public TMP_Dropdown classeDropdown;
    public RawImage classeImg;
    public List<string> classi = new();
    public List<Texture> immaginiClassi = new();

    void Start()
    {
        // Ess1
        StartPannello();
        pannelloToggle.onValueChanged.AddListener(OnOfPannello);
        chiudiPannello.onClick.AddListener(() => StartPannello());

        // Ess2
        textTog.onValueChanged.AddListener((val) => pnlText.gameObject.SetActive(val));
        imgTog.onValueChanged.AddListener((val) => pnlImg.gameObject.SetActive(val));
        btnTog.onValueChanged.AddListener((val) => pnButton.gameObject.SetActive(val));

        pnlText.gameObject.SetActive(textTog.isOn);
        pnlImg.gameObject.SetActive(imgTog.isOn);
        pnButton.gameObject.SetActive(btnTog.isOn);

        // Ess Dropdown 1
        colorDropdown.onValueChanged.AddListener(CambiaColore);
        CambiaColore(0);

        pannelloImage = pannello.GetComponent<Image>();

        // Ess DropDown 2
        difficoltaDropdown.onValueChanged.AddListener(CambiaDifficolta);

        // Ess Dropdown 3
        classi.Add("Guerriero");
        classi.Add("Ladro");
        classi.Add("Mago");
        classi.Add("Paladino");
        classi.Add("Druido");

        PopolaDropdownClassi();
        classeDropdown.onValueChanged.AddListener(CambiaClasse);
    }

    void Update()
    {
        AggiornaStato();
    }

    void StartPannello()
    {
        pannelloToggle.isOn = false;
        OnOfPannello(false);
    }

    void OnOfPannello(bool value)
    {
        pannello.SetActive(value);
    }

    void AggiornaStato()
    {
        pannelloStatusText.text = pannello.activeSelf ? "On" : "Off";
    }

    void CambiaColore(int scelta)
    {
        if (pannelloImage == null) { return; }

        Color newColor;

        switch (scelta)
        {
            case 0:
                newColor = Color.whiteSmoke;
                break;

            case 1:
                newColor = Color.red;
                break;

            case 2:
                newColor = Color.green;
                break;

            case 3:
                newColor = Color.blue;
                break;

            default:
                newColor = Color.white;
                break;
        }

        pannelloImage.color = newColor;
    }

    void CambiaDifficolta(int scelta)
    {
        string difficolta;

        switch (scelta)
        {
            case 0:
                difficolta = $"Facile";
                break;

            case 1:
                difficolta = $"Medio";
                break;

            case 2:
                difficolta = $"Difficile";
                break;


            default:
                difficolta = $"Facile";
                break;
        }

        difficoltaText.text = $"Difficoltà: {difficolta}";
    }

    void PopolaDropdownClassi()
    {
        classeDropdown.ClearOptions(); // cancella tutte le opzioni già presenti
        classeDropdown.AddOptions(classi); //aggiunge le opzioni contenute nella lista

        if (classi.Count > 0)
        {
            CambiaClasse(0);
        }
    }

    void CambiaClasse(int scelta)
    {
        if (scelta < 0 || scelta >= immaginiClassi.Count)
        {
            classeImg.texture = null; //ritorna null se la scelta è minore di 0 o maggiore della lunghezza della lista di immagini
            return;
        }

        classeImg.texture = immaginiClassi[scelta];
    }
}