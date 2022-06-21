using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
[RequireComponent(typeof(InputField))]
    public class PlayerNameInputField : MonoBehaviour
    {
        #region Private Constants

        const string PlayerNamePrefKey = "PlayerName";

        #endregion

        #region  Monobehaviour Callbacks

        void Start()
        {
            string defaultName = string.Empty;
            InputField _inputfield = GetComponent<InputField>();
            if (_inputfield != null)
            {
                if (PlayerPrefs.HasKey(PlayerNamePrefKey))
                {
            defaultName = PlayerPrefs.GetString(PlayerNamePrefKey);
                }
            }
            _inputfield.text = defaultName;
            PhotonNetwork.NickName = defaultName;
        }
        #endregion
        #region  Public Methods
        public void SetPlayerName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("Player Name is null or empty");
                return;
            }
            PhotonNetwork.NickName = value;

            PlayerPrefs.SetString("playerNamePrefKey", value);
        }
        #endregion
    }