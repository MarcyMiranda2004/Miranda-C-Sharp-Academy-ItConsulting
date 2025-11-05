using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonDinamici : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform content;

    void Start()
    {
        for (int i = 1; i <= 20; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, content);
            TMP_Text text = newButton.GetComponentInChildren<TMP_Text>();
            if (text != null) text.text = "Pulsante " + i;

            int index = i;
            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log("Hai cliccato il pulsante " + index);
            });
        }
    }
}
