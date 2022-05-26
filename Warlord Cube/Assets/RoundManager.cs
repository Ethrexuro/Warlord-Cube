using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
[Tooltip("Round Settings")]
public int maxkills = 10;
public float timelimit = 90;
public TMP_Text TimerUI;
public int RoundTime;
[Tooltip("Players")]
public GameObject[] players;
public Transform[]spawnPoints;
public GameObject PanelEndGame;
public TMP_Text P1;
public TMP_Text P1Score;
public TMP_Text P2;
public TMP_Text P2Score;

public Transform UpperRightLimit, LowerLeftLimit;

#region Singleton pattern
public static RoundManager instance;
private void Awake()
{
    if(instance != null)
    {
        Destroy(gameObject);
    }
    else
    {
        instance = this;
    }
    StartCoroutine(Timer(RoundTime));
}
#endregion
public void AddScore(int PlayerDying, int PlayerKilling)
{
    if (PlayerDying == PlayerKilling || PlayerKilling == 0) players[PlayerDying-1].GetComponent<PlayerData>().score--;
    else {
        players[PlayerKilling-1].GetComponent<PlayerData>().score++;
        var h = players[PlayerKilling-1].GetComponent<Health>();
        h.UI.UpdatePlayerUI(h.PD.PlayerName, h.PD.score, h.health, h.maxHealth);
         if(players[PlayerKilling-1].GetComponent<PlayerData>().score >= maxkills)
    {
        EndGame();
    }
    }
}
public IEnumerator Timer (int time){
    WaitForSeconds WFS = new WaitForSeconds(1f);
    while (time > 0){
        time--;
        DisplayTimer(time);
        yield return WFS;
    }
    
}
public void SpawnPlayer(int PlayerNum)
{
    Debug.Log("Attempt to spawn");
    var x = Random.Range(UpperRightLimit.position.x, LowerLeftLimit.position.x);
    var z = Random.Range(UpperRightLimit.position.z, LowerLeftLimit.position.z);
    var SpawnPoint = new Vector3(x, 1, z);

    players[PlayerNum - 1].transform.position = spawnPoints[PlayerNum-1].position;
    var PlayerHealth = players[PlayerNum - 1].GetComponent<Health>();
    PlayerHealth.health = PlayerHealth.maxHealth;
    PlayerHealth.isDead = false;
    PlayerHealth.Invoke("ResetDamage",1);
    StartCoroutine(ActivatePlayer(players[PlayerNum-1]));
}
IEnumerator ActivatePlayer(GameObject player)
{
    yield return new WaitForSeconds(2);
    player.SetActive(true);
    Debug.Log("Calling Code Reuntine");
}
private void OnDrawGizmos()
{
    var UR = (UpperRightLimit.position);
    var LL = (LowerLeftLimit.position);
    Gizmos.color = Color.red;
    Gizmos.DrawCube(UR, UpperRightLimit.localScale);
    Gizmos.DrawCube(LL, LowerLeftLimit.localScale);
    Gizmos.color = Color.yellow;
    Gizmos.DrawLine(UR, new Vector3(LL.x, UR.y, UR.z));
    Gizmos.DrawLine(UR, new Vector3(UR.x, UR.y, LL.z));
    Gizmos.DrawLine(LL, new Vector3(UR.x, LL.y, LL.z));
    Gizmos.DrawLine(LL, new Vector3(LL.x, LL.y, UR.z));
}
public void DisplayTimer(int time)
{
    var minutes = Mathf.Floor(time / 60).ToString("00");
    var seconds = (time % 60). ToString("00");

    TimerUI.text = minutes + ":" + seconds;
}
public void EndGame(){
    PanelEndGame.GetComponent<CanvasGroup>().alpha = 1;
    var player1 = players[0].GetComponent<PlayerData>();
    var player2 = players[1].GetComponent<PlayerData>();
    P1.text = player1.PlayerName;
    P2.text = player2.PlayerName;
    P1Score.text = player1.score.ToString();
    P2Score.text = player2.score.ToString();
    Debug.Log("Game Over");
}
/*int timesKilled = 0;

timesKilled ++
if (timesKilled >= 10)
{

}
public void EnemyKilled(){
    timesKilled ++ 1
    if (timesKilled >= 10){
        
    }
}*/
}