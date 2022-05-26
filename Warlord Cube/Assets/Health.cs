using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
public float health;
public float maxHealth;
public bool isDead= false;
public bool canBeDamaged = true;
public PlayerUIupdator UI;
public PlayerData PD;
private void Start()
{
    PD = GetComponent<PlayerData>();
    UI.UpdatePlayerUI(PD.PlayerName, PD.score, health, maxHealth);
}
void OnEnable(){
        UI.UpdatePlayerUI(PD.PlayerName, PD.score, health, maxHealth);
}
public void TakeDamage(int damage, int PlayerAttacking = 0)
{
    if (isDead && !canBeDamaged) return;
    health -= damage;
    UI.UpdatePlayerUI(PD.PlayerName, PD.score, health, maxHealth);
    if(health <= 0)
    {
    health = 0;
    Death(PlayerAttacking);
    }
canBeDamaged = false;
Invoke("ResetDamage", 1);
}
public void Death(int killedBy)
{
isDead = true;
canBeDamaged = false;
var PlayerNum = GetComponent<PlayerData>().PlayerNumber;
Debug.Log("Player" + PlayerNum + "killed by player" + killedBy);
RoundManager.instance.AddScore(PlayerNum,killedBy);
RoundManager.instance.SpawnPlayer(PlayerNum);
gameObject.SetActive(false);
}
private void ResetDamage()
{
    canBeDamaged = true;
}
}
