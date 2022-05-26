using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
    private void Awake(){
        #region SingLeton pattern
        if (instance != null){
            Destroy (gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public string P1;
    public string P2;
    public TMP_InputField Player1_Inputfield;
    public TMP_InputField Player2_Inputfield;
    public void StoreNames(){
        P1 = Player1_Inputfield.text;
        P2 = Player2_Inputfield.text;
    }
    #endregion
}
