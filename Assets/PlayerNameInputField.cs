using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

using System.Collections;

namespace com.MyCompany.MyGame{
    [RequireComponent(typeof(InputField))]
    public class PlayerNameInputField : MonoBeahviour
    {
        #region Private Constants

        const string PlayerNamePrefKey = "PlayerName";

        #endregion

        #region  Monobehaviour Callbacks

        void Start (){
            string defaultName = string.Empty;
            InputField _inputfield = this.GetComponent<InputField>();
            if (_inputfield!=null){
                if (PlayerPrefs.HasKey(PlayerNamePrefKey)){

                }
            }
            defualtName - PlayerPrefs.Getstring(PlayerNamePrefKey);
            _inputfield.text = defaultName;
        }
    }
    PhotonNetwork.NickName = defaultName;
}

#endregion

#region  Public Methods

public void SetPlayerName(string value){
    if (string.IsNullOrEmpty(value)){
        Debug.LogError("Player Name is null or empty");
        return;
    }
    PhotonNetwork.Nickname = value;

    PlayerPrefs.SetString(playerNamePrefKey,value);
}

#endregion
