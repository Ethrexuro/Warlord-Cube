using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
[Tooltip("Player Identity")]
public string PlayerName;
public int PlayerNumber;

[Tooltip("Player Score")]
public int score;
public void Awake(){
    if (PlayerNumber == 1)PlayerName = CharacterManager.instance.P1;
    if (PlayerNumber == 2)PlayerName = CharacterManager.instance.P2;
}
    }
