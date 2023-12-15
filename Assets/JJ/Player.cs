using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public float _maxHealth = 3;
     
    public float _currentHealth;

    [SerializeField] public Healthbar _healthbar;


    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;

        _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "OhNo")
        {
            _currentHealth--;
        }
        if (_currentHealth <= 0)
        {
            SceneManager.LoadScene("2");
        }
        else
        {
            _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);

        }
    }
}
