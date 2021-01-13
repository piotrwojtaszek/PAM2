using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float health = 0f;
    public float maxHealth = 200f;
    bool destroyed = false;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f&& destroyed==false)
        {

            destroyed = true;
            KillMe();
        }
            
    }

    void KillMe()
    {
        GameManager.instance.CallDeadMenu();
        Debug.LogWarning("KILL ME");
    }
}
