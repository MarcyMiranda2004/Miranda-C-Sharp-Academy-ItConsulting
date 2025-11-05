using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] private float _speedMultiplier = 2f;
    [SerializeField] private float _duration = 3f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger rilevato con: {other.name}");

        if (other.CompareTag("Player"))
        {
            PGMove ms = other.GetComponent<PGMove>();

            if (ms != null)
            {
                StartCoroutine(SpeedBoost(ms));
                Debug.Log("Velocità raddoppiata!");
            }
        }
    }

    private IEnumerator SpeedBoost(PGMove ms)
    {
        var originalSpeed = ms.GetSpeed;
        ms.SetSpeed(originalSpeed * _speedMultiplier);

        yield return new WaitForSeconds(_duration);
    }
}
