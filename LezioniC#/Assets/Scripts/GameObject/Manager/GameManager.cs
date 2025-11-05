using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton del GM
    private static GameManager _instance;
    public static GameManager Instance { get; private set; }

    [SerializeField] private int _score; // serializzo il punteggio

    private float _timer = 0f; // timer iniziale = 0
    private float _prevTimer; // timer precedente
    private float _bestTimer; // timer migliore

    [SerializeField] private bool _startTimer; //serializzo un bool per avviare e fermare il timer
    public float GetPrevTimer() => _prevTimer;
    public float GetBestTimer() => _bestTimer;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // se l'istanza è null ne crea una nuova eliminando le vecchie
            DontDestroyOnLoad(gameObject); // mantiene il GM tra le scene
        }
        else
        {
            Destroy(gameObject); // se l'istanza gia esiste elimina quelle ine cesso
        }
    }

    void Update()
    {
        if (_startTimer) _timer += Time.deltaTime; // aggiorna il timer
    }

    // Incrementa e Logga il punteggio
    public int ScoreInc(int amount)
    {
        _score += amount;
        Debug.Log("Score: " + _score);
        return _score;
    }

    public float Timer => _timer; // set del timer iniziale rendendolo pubblico

    public void StartTimer()
    {
        _startTimer = true; // avvia il timer
    }

    public void StopTimer()
    {
        _startTimer = false;

        // Quando fermo il timer, aggiorno prev e best
        _prevTimer = _timer;

        if (_bestTimer == 0f || _timer < _bestTimer)
        {
            _bestTimer = _timer;
            Debug.Log("🏁 Nuovo record!");
        }
    }

    public void ResetTimer()
    {
        _timer = 0f; // resetta il timer
    }


}
