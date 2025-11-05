using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Per ricevere eventi su un oggetto UI, questo script deve essere associato a un GameObject
// che ha anche un componente grafico (es. Image, Text, Button) con "Raycast Target" abilitato.
public class PressHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [Header("Riferimenti UI - Ess 2")]
    [SerializeField] private Button _button;
    [SerializeField] private float _longPress = 0.5f;

    private float _pressStartTime;
    private int _clickCount = 0;

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressStartTime = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        float pressDuration = Time.time - _pressStartTime;

        if (pressDuration >= _longPress)
        {
            Debug.Log($"Pressione Lunga");
        }
        else
        {
            Debug.Log($"Pressione Breve");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _clickCount++;
        Debug.Log($"Tasto premuto: {_clickCount} volte");
    }

}