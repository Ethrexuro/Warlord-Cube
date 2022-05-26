using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUIupdator : MonoBehaviour
{
public TMP_Text playerName;
public TMP_Text playerScore;
public Slider healthUI;

public void UpdatePlayerUI(string name, int score, float health, float maxHealth)
{
    Debug.Log("update UI" + name + score + health + maxHealth);
    playerName.text = name;
    playerScore.text = score.ToString();
    healthUI.maxValue = maxHealth;
    healthUI.minValue = 0;
    healthUI.value = health;
}
}
