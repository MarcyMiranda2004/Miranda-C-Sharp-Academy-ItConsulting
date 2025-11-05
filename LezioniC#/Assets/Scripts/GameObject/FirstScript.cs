using UnityEngine;

public class FirstScript : MonoBehaviour
{

    [SerializeField] private int _cubeToSpawn = 1;
    [SerializeField] private GameObject _prefabToSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"Mia Posizione: {transform.position}");
        // Debug.Log($"Sono nel GameObject:  {gameObject.name}")

        // Instantiate();

        for (int i = 0; i < _cubeToSpawn; i++)
        {
            Instantiate(_prefabToSpawn, Vector3.zero, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // spostamenti direzionali
        transform.position += new Vector3(0f, 0f, 0.1f);

        // il quaternione risolve i problemi degli angoli di eurelo dove abbiamo 4 valori x, y, z, v
        // transform.rotation += new Quaternion(0f, 0,01f, 0f, 1f); //non puo essere sommato cosi

        // transform.Rotate(Quaternion.Euler(new Vector3(0, 0.1f, 0f)));
    }
}
