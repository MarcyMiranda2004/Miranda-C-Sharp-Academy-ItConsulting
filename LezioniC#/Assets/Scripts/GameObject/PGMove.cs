using UnityEngine;

public class PGMove : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _rotationSpeed = 120f;

    public float GetSpeed => _speed;
    public void SetSpeed(float newSpeed) => _speed = newSpeed;

    private float _rotationInput;
    private Vector3 _moveDirection;

    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _color;
    private Color _oldColor;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _oldColor = _renderer.material.color;
    }

    void Update()
    {
        HandleInput();
        ChangeColor();
    }

    private void HandleInput()
    {
        _moveDirection = Vector3.zero;
        _rotationInput = 0f;

        // Avanti / Indietro
        if (Input.GetKey(KeyCode.W)) _moveDirection = transform.forward;
        else if (Input.GetKey(KeyCode.S)) _moveDirection = -transform.forward;

        // Rotazione
        if (Input.GetKey(KeyCode.A)) _rotationInput = -1f;
        else if (Input.GetKey(KeyCode.D)) _rotationInput = 1f;
    }

    void FixedUpdate()
    {
        // Movimento
        if (_moveDirection != Vector3.zero)
        {
            _rb.MovePosition(_rb.position + _moveDirection * _speed * Time.fixedDeltaTime);
        }

        // Rotazione
        if (_rotationInput != 0f)
        {
            Quaternion rotation = Quaternion.Euler(0f, _rotationInput * _rotationSpeed * Time.fixedDeltaTime, 0f);
            _rb.MoveRotation(_rb.rotation * rotation);
        }
    }

    private void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _renderer.material.color =
                (_renderer.material.color == _oldColor) ? _color : _oldColor;
        }
    }
}
