using UnityEngine;
using TMPro;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    
    [SerializeField] private GameObject _gameOverObject;

    public void UpdateHealthDisplay(int currentHealth)
    {
        _healthText.text = $"HP: {currentHealth}";
    }

    public void ShowGameOver()
    {
        if (_gameOverObject != null)
        {
            _gameOverObject.SetActive(true);
        }
    }
}