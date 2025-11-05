using UnityEngine;
using UnityEngine.UI;

public class Pannello2Manager : MonoBehaviour
{
    public Button bottonePannello;
    public GameObject pannello;
    private bool statePannello = false;

    void Start()
    {
        pannello.SetActive(statePannello);
        bottonePannello.onClick.AddListener(TogglePannello);
    }

    void TogglePannello()
    {
        statePannello = !statePannello;

        pannello.SetActive(statePannello);
    }
}
