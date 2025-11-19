using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour
{
    private int _currentHealth = 3;
    private HealthView _healthView;
    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;

    [Inject]
    public void Construct(HealthView view)
    {
        _healthView = view;
    }

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        _healthView.UpdateHealthDisplay(_currentHealth);
        
        Time.timeScale = 1f;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"Player took damage! HP: {_currentHealth}");

        transform.position = _startPosition;
        if (_rigidbody != null) _rigidbody.linearVelocity = Vector2.zero;

        _healthView.UpdateHealthDisplay(_currentHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Camera cam = Camera.main;
        if (cam != null)
        {
            cam.transform.position = new Vector3(_startPosition.x, _startPosition.y, cam.transform.position.z);
        }

        _healthView.ShowGameOver();
        
        Time.timeScale = 0f; 
        
        Debug.Log("Game Over");
    }
}