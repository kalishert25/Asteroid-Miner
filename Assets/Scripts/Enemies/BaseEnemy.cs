using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseEnemy : MonoBehaviour 
{
    public Transform player;
    [SerializeField]
    private int maxHealth;
    private int currentHealth;
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int value)
    {
        currentHealth -= value;
        if(currentHealth <= 0)
        {
            HandleDeath();
        }
    }
    private void HandleDeath()
    {
        Destroy(gameObject);
    }

}
