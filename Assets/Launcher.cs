using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace com.MyCompany.MyGame
{
    public class Launcher : MonoBehaviourPunCallbacks
{
    #region Private Serializable Fields

    #endregion

    #region Private Fields

    string gameVersion = "1";

    #endregion

    #region  MonoBehaviour CallBacks

    void Awake(){
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start(){
        Connect();
    }

    #endregion

    #region Public Fields

    public void Connect(){
        if (PhotonNetwork.IsConnected){
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    #endregion

    #region MonobahviourPunCallbacks Callbacks

    public override void OnConnectedToMaster(){
        Debug.LogWarningFormat("OnConnectedToMaster() was called by PUN");
    }

    public override void OnDisconnected(DisconnectCause cause){
        Debug.LogWarningFormat("OnDissconnected() was called by PUN with reason {0}", cause);
    }

    #endregion

    public override void OnJoinRandomFailed(short returnCode, string message){
        Debug.Log("Successfully Create Room");
            PhotonNetwork.CreateRoom(null, new RoomOptions{ MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom(){
        Debug.Log("Successfully joined Room");
    }
    [Tooltip("The Maxium number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 2;
}

}