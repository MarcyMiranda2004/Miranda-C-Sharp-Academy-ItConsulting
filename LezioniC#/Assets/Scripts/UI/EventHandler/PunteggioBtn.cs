using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PunteggioBtn : MonoBehaviour
{
    [SerializeField] private Button _plus;
    [SerializeField] private Button _less;
    [SerializeField] private TextMeshProUGUI _punteggioText;

    private int _punteggio = 0;

    void Start()
    {
        UpdatePunteggioText();

        _plus.onClick.AddListener(PunteggioPlus);
        _less.onClick.AddListener(PunteggioLess);
    }

    private void UpdatePunteggioText()
    {
        _punteggioText.text = $"Punteggio: {_punteggio}";
    }

    private void PunteggioPlus()
    {
        _punteggio++;
        UpdatePunteggioText();
        Debug.Log($"Punteggio incrementato: {_punteggio}");
    }

    private void PunteggioLess()
    {
        _punteggio--;
        UpdatePunteggioText();
        Debug.Log($"Punteggio incrementato: {_punteggio}");
    }

}