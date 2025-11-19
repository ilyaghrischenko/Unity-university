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
            Camera cam = Camera.main;
            if (cam != null)
            {
                _gameOverObject.transform.position = new Vector3(
                    cam.transform.position.x, 
                    cam.transform.position.y, 
                    cam.transform.position.z + 10f
                );
            }
            _gameOverObject.SetActive(true);
        }
    }
}