using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float _timeDestroy = 5f;

    void Start()
    {
        Destroy(gameObject, _timeDestroy); //settiamo la distruzione del proiettile dopo 5 secondi 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Colpito bersaglio: " + collision.gameObject.name);
            GameManager.Instance.ScoreInc(1);
            Destroy(collision.gameObject); // distrugge il bersaglio
        }

        Destroy(gameObject); // distrugge il proiettile
    }
}
