using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _button;

    void OnEnable()
    {
        _button.onClick.AddListener(() => Interazione());
        _button.onClick.AddListener(InterazioneSemplice);
    }

    public void Interazione()
    {
        Debug.Log($"Bottone Premuto!");
    }

    public void InterazioneSemplice()
    {

    }
}