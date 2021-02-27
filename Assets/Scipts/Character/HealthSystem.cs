using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int health;

    public System.Action OnTakeDamage;
    public System.Action OnDead;
    public bool IsAlive;


    public void TakeDamage(int damage)
    {
        if (!IsAlive) return;
        health -= damage;
        OnTakeDamage?.Invoke();
        if(health<=0)
        {
            OnDead?.Invoke();
            IsAlive = false;
        }
        
    }


}
