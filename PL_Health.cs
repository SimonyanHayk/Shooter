using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PL_Health : MonoBehaviour
{
    public float mainHealth;
    
    public float mainArmor;

    [Range(0, 100)]
    public float health;

    [HideInInspector]
    public float healthMin = 0f;
    [HideInInspector]
    public float healthMax = 100f;

    [Range(0, 100)]
    public float extraHealth;

    [HideInInspector]
    public float extraHealthMin = 0f;
    [HideInInspector]
    public float extraHealthMax = 100f;

    [Range(0, 100)]
    public float armor;

    [HideInInspector]
    public float armorMax = 100f;
    [HideInInspector]
    public float armorMin = 0f;

    [Range(0, 100)]
    public float extraArmor;

    [HideInInspector]
    public float extraArmorMax = 100f;
    [HideInInspector]
    public float extraArmorMin = 0f;

    public void Update()
    {
        mainHealth = health + extraHealth;
        mainArmor = armor + extraArmor;
    }

    public void PlayerTakeDamage (float DamageAmount)
    {
        
        if (armor > armorMin && extraHealth > extraHealthMin && extraArmor <= extraArmorMin)
        {
            armor -= DamageAmount * 2f / 3f;
            extraHealth -= DamageAmount / 3f;            
        }
        else if (armor > armorMin && extraHealth <= extraHealthMin && extraArmor <= extraArmorMin)
        {
            armor -= DamageAmount * 2f / 3f;
            health -= DamageAmount / 3f;            
        }
        else if (armor <= armorMin && extraHealth > extraHealthMin && extraArmor <= extraArmorMin)
        {
            extraHealth -= DamageAmount;
            
        }
        else if (health > healthMin && armor <= armorMin && extraHealth <= extraHealthMin && extraArmor <= extraArmorMin)
        {
            health -= DamageAmount;            
        }
        else if (extraArmor > extraArmorMin && extraHealth > extraHealthMin )
        {
            extraArmor -= DamageAmount * 2f / 3f;            
            extraHealth -= DamageAmount / 3f;            
        }                
        else if (extraArmor > extraArmorMin &&  extraHealth <= extraHealthMin)
        {
            extraArmor -= DamageAmount * 2f / 3f;
            health -= DamageAmount / 3f;            
        }        
        else if (health <= healthMin)
        {
            Die();
        }

        if (extraHealth <= 0)
        {
            extraHealth = 0;
        }

        if (armor <= 0)
        {
            armor = 0;
        }

        if (extraArmor <= 0)
        {
            extraArmor = 0;
        }

    }

    public void Die()
    {
        Debug.Log("PlayerDead");
    }

}
