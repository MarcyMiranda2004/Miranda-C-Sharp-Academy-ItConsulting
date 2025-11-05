using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionFocusHandles : MonoBehaviour,
IBeginDragHandler,
IDragHandler,
IEndDragHandler,
ISelectHandler,
IDeselectHandler,
IPointerDownHandler
{
    [Header("Riferimenti UI - Ess 3")]
    [SerializeField] private RawImage _imgParent;
    [SerializeField] private RawImage _img;
    [SerializeField] private RectTransform _parentRect;
    [SerializeField] private RectTransform _imgRect;

    private Color _selectedColor = Color.brown;
    private Color _deselectedColor = Color.white;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("mi stai trascinando");
    }

    public void OnDrag(PointerEventData eventData)
    {
        _imgRect.position += (Vector3)eventData.delta;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("non mi stai trascinando");
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Oggetto selezionato");
        _img.color = _selectedColor;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("Oggetto deselezionato");
        _img.color = _deselectedColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }


}