using UnityEngine;

public class Timers : MonoBehaviour
{
    public GameManager gmi;

    void Awake()
    {
        gmi = GameManager.Instance;

        if (gmi == null) Debug.LogError("GameManager non presente nell scena!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Start"))
        {
            gmi.ResetTimer();
            gmi.StartTimer();
            Debug.Log("Timer avviato!");
        }

        if (other.CompareTag("Goal"))
        {
            gmi.StopTimer();
            Debug.Log("Timer fermato a: " + gmi.Timer.ToString("F2") + " secondi");
        }
    }

}