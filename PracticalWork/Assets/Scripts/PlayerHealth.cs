using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour
{
    private int _currentHealth = 3;
    private HealthView _healthView;

    [Inject]
    public void Construct(HealthView view)
    {
        _healthView = view;
    }

    private void Start()
    {
        _healthView.UpdateHealthDisplay(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"Player took damage! HP: {_currentHealth}");

        if (_currentHealth < 0) _currentHealth = 0;

        _healthView.UpdateHealthDisplay(_currentHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Game Over");
    }
}