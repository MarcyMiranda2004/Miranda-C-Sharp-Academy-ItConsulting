using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _shootForce = 6f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Fire();
        }
    }

    private void Fire()
    {
        // Crea il proiettile
        var bullet = Instantiate(_prefabToSpawn, _spawnPoint.position, _spawnPoint.rotation);
        bullet.SetActive(true);

        // Aggiungi forza al rigidbody
        var rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(_spawnPoint.forward * _shootForce, ForceMode.Impulse);
        }

        bullet.tag = "Bullet"; // tag per organizzazione
    }
}
