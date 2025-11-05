using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUp : MonoBehaviour
{
    [Header("Riferimenti UI")]
    public GameObject finestraPopup;
    public Button apriFinestraButton;
    public Button annullaButton;
    public Button confermaButton;
    public TMP_Text testoPopup;

    private void Start()
    {
        finestraPopup.SetActive(false);

        apriFinestraButton.onClick.AddListener(ApriFinestra);
        annullaButton.onClick.AddListener(ChiudiFinestra);
        confermaButton.onClick.AddListener(Conferma);
    }

    void ApriFinestra()
    {
        finestraPopup.SetActive(true);
        testoPopup.text = "Sei sicuro di voler continuare?";
    }

    void ChiudiFinestra()
    {
        finestraPopup.SetActive(false);
    }

    void Conferma()
    {
        Debug.Log("Hai premuto Conferma!");
        finestraPopup.SetActive(false);
    }
}
