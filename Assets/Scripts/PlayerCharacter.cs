using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int maxHealth = 5;
    private int health;

    // Use this for initialization 
    void Start()
    {
        health = maxHealth;
    }

    public void Hit()
    {
        health -= 1;
        float healthPercentage = (float)health / (float)maxHealth;
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercentage);
        Debug.Log("Health: " + health + ", percentage: " + healthPercentage);
        if (health <= 0)
        {
            //Debug.Break();
            Messenger.Broadcast(GameEvent.PLAYER_DEAD);
        }

    }

    public void FirstAid(int healthAdded)
    {
        health += healthAdded;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        float healthPercent = ((float)health) / maxHealth;
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercent);
    }
}
