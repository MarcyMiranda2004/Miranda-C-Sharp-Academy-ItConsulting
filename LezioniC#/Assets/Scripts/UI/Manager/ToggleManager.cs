using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    [Header("Riferimenti UI")]
    public Toggle objToggle;
    public GameObject obj;

    void Start()
    {
        objToggle.isOn = false;
        OnOffToggle(false);

        objToggle.onValueChanged.AddListener(OnOffToggle);
    }

    void OnOffToggle(bool value)
    {
        obj.SetActive(value);
    }
}
