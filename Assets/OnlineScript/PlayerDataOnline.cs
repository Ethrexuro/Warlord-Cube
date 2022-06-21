using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerDataOnline : MonoBehaviour
{
[Tooltip("Player Identity")]
public string PlayerName;
public int PlayerNumber;

public PhotonView view;

[Tooltip("Player Score")]
public int score;
public void Awake(){
    view = GetComponent<PhotonView>();
    PlayerName = view.Controller.NickName;
    PlayerNumber = view.ControllerActorNr;
}
    }
