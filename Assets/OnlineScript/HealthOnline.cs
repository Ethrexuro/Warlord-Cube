using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class HealthOnline : MonoBehaviour
{
public float health;
public float maxHealth;
public bool isDead = false;
public bool canBeDamaged = true;
public PlayerUIupdator UI;
public PlayerDataOnline PD;
public PhotonView view;
private bool isStarted = false;
private void start(){
    PD = GetComponent<PlayerDataOnline>();
    view = PD.view;
    if(PD.PlayerNumber == 1){
        UI = GameObject.FindGameObjectWithTag("Player1Canvas").GetComponent<PlayerUIupdator>();
    }
    else if (PD.PlayerNumber ==2){
        UI = GameObject.FindGameObjectWithTag("Player2Canvas").GetComponent<PlayerUIupdator>();
    }
    UI.UpdatePlayerUI(PD.PlayerName, PD.score, health, maxHealth);
    RoundManagerOnline.instance.view.RPC("CollectReferencesToPlayers", RpcTarget.All);
    isStarted = true;
}
void OnEnable(){
    if (isStarted);
//    UI.UpdatePlayerUI(PD.PlayerName, PD.score, health, maxHealth);
}
[PunRPC]
public void TakeDamage(int damage, int PlayerAttacking = 0){
    if (isDead && !canBeDamaged) return;
    health -= damage;
    UI.UpdatePlayerUI(PD.PlayerName, PD.score, health, maxHealth);
    if(health <= 0){
        health = 0;
        Death(PlayerAttacking);
    }
    canBeDamaged = false;
    Invoke("ResetDamage", 1);
}
public void Death(int KilledBy){
    isDead = true;
    canBeDamaged = false;
    var PlayerNum = PD.PlayerNumber;
    Debug.Log("Player" + PlayerNum + "Killed by player" + KilledBy);
    RoundManagerOnline.instance.view.RPC("AddScore", RpcTarget.All, PlayerNum, KilledBy);
    RoundManagerOnline.instance.view.RPC("SpawnPlayer", RpcTarget.All, PlayerNum);
    gameObject.SetActive(false);
}
private void ResetDamage(){
    canBeDamaged = true;
}
}
