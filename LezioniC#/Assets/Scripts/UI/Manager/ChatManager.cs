using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public TMP_InputField inputNome;
    public TMP_InputField inputMessaggio;
    public Button sendButton;
    public Transform contentParent;
    public GameObject messagePrefab;
    public ScrollRect scrollRect;

    void Start()
    {
        sendButton.onClick.AddListener(InviaMessaggio);
        inputMessaggio.onSubmit.AddListener(_ => InviaMessaggio());
    }

    void InviaMessaggio()
    {
        if (string.IsNullOrWhiteSpace(inputNome.text) || string.IsNullOrWhiteSpace(inputMessaggio.text))
            return;

        GameObject newMessage = Instantiate(messagePrefab, contentParent);
        TMP_Text[] texts = newMessage.GetComponentsInChildren<TMP_Text>();
        if (texts.Length >= 2)
        {
            texts[0].text = inputNome.text;
            texts[1].text = inputMessaggio.text;
        }

        inputMessaggio.text = "";

        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }
}
