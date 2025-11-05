using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [Header("Riferimenti UI - Ess 1")]
    public TMP_InputField inputName;
    public TextMeshProUGUI nameText;

    [Header("Riferimenti UI - Ess 2")]
    public TMP_InputField inputNumber;
    public TextMeshProUGUI numberText;

    [Header("Riferimenti UI - Ess 3")]
    public TMP_InputField inputNome;
    public TMP_InputField inputEmail;
    public TMP_InputField inputMessaggio;
    public Button sendButton;

    public Color coloreNormale = Color.white;
    public Color coloreErrore = Color.red;


    void Start()
    {
        inputName.onSubmit.AddListener(NameSub);

        inputNumber.onSubmit.AddListener(MaggioreDi100);

        sendButton.onClick.AddListener(SetForm);
    }

    void NameSub(string text)
    {
        CambiaNome();
    }

    void CambiaNome()
    {
        nameText.text = inputName.text;
        inputName.text = "";
    }

    void MaggioreDi100(string number)
    {
        int n = int.Parse(number);

        if (n > 100)
        {
            numberText.text = $"si, {n} è maggiore di 100";
        }
        else
        {
            numberText.text = $"no, {n} non è maggiore di 100";
        }

        inputNumber.text = "";
    }

    void SetForm()
    {
        bool isOk = true;

        if (string.IsNullOrWhiteSpace(inputNome.text))
        {
            inputNome.image.color = coloreErrore;
            isOk = false;
        }

        if (string.IsNullOrWhiteSpace(inputEmail.text))
        {
            inputEmail.image.color = coloreErrore;
            isOk = false;
        }

        if (string.IsNullOrWhiteSpace(inputMessaggio.text))
        {
            inputMessaggio.image.color = coloreErrore;
            isOk = false;
        }

        if (isOk == true)
        {
            Debug.Log($"Form Inviato");
        }
        else
        {
            Debug.Log($"Errore, compila tutti i campi");
        }


    }
}