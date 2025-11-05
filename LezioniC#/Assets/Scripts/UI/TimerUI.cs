// using UnityEngine;
// using TMPro;

// public class TimerUI : MonoBehaviour
// {
//     [SerializeField] private TextMeshProUGUI _timerText;
//     [SerializeField] private TextMeshProUGUI _bestTimerText;
//     [SerializeField] private TextMeshProUGUI _prevTimerText;

//     private GameManager _gm;

//     void Start()
//     {
//         _gm = GameManager.Instance;

//         if (_gm == null)
//         {
//             Debug.LogError("⚠️ GameManager non trovato nella scena!");
//         }
//     }

//     void Update()
//     {
//         if (_gm == null) return;

//         // Aggiorna il timer in tempo reale
//         _timerText.text = $"⏱️ Tempo attuale: {_gm.Timer:F2}s";

//         // Aggiorna anche best e prev
//         _bestTimerText.text = $"🏆 Migliore: {_gm.GetBestTimer():F2}s";
//         _prevTimerText.text = $"📜 Precedente: {_gm.GetPrevTimer():F2}s";
//     }
// }
