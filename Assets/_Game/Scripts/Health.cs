using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 3;
    [SerializeField] private Level01Controller scoreCounter;

    [SerializeField] private Shootable _shootable;

    private void OnEnable()
    {
        // Watch Shot event
        if (_shootable != null)
        {
            _shootable.Shot.AddListener(TakeDamage);
        }
    }

    private void OnDisable()
    {
        // Stop watching Shot event
        if(_shootable != null)
        {
            _shootable.Shot.RemoveListener(TakeDamage);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        scoreCounter.IncreaseScore(5);
        Debug.Log("Health Remaining: " + _currentHealth);
        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        scoreCounter.IncreaseScore(10);
        gameObject.SetActive(false);
    }
}
