using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
public float health;
public float maxHealth;
public bool isDead= false;
public bool canBeDamaged = true;
public void TakeDamage(int damage, int PlayerAttacking = 0)
{
    if (isDead && !canBeDamaged) return;
    health -= damage;

    if(health <= 0)
    {
    health = 0;
    Death(PlayerAttacking);
    }
canBeDamaged = false;
Invoke("ResetDamage", 1);
}
public void Death(int KilleBy)
{
isDead = true;
canBeDamaged = false;
gameObject.SetActive(false);
}
private void ResetDamage()
{
    canBeDamaged = true;
}
}
