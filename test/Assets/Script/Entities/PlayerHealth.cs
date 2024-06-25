using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 3;
    
    private int currentHealth;
    
    public Healthbar healthbar;

    public bool HasTakenDamage {get; set;}
    

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    private void Update(){
            //    Debug.Log(currentHealth);
        healthbar.SetHealth(currentHealth);
    }

    public void Damage(float damageAmount)
    {
        HasTakenDamage = true;
        currentHealth -= (int) (damageAmount);

        if (currentHealth <= 0){
            Die();
        }
    }

    private void Die(){
        Destroy(gameObject);
    }
}
