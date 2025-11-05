using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Per ricevere eventi su un oggetto UI, questo script deve essere associato a un GameObject
// che ha anche un componente grafico (es. Image, Text, Button) con "Raycast Target" abilitato.
public class UIintHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Riferimenti UI - Ess 1")]
    [SerializeField] private RawImage _img;
    private Color _red = Color.red;
    private Color _white = Color.white;



    private void Awake()
    {
        if (_img == null)
            _img = GetComponent<RawImage>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _img.color = _red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _img.color = _white;
    }
}