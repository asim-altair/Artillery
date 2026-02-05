using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManger : MonoBehaviour
{
    public bool playerTurn = true;
    public Player player;
    public TextMeshProUGUI moneyUI;

    void Update(){
        moneyUI.text = player.money.ToString();   

        if(Input.GetKeyDown(KeyCode.S)){
            SaveSystem.Save(player);
            Debug.Log("Saved!");
        } 
        if(Input.GetKeyDown(KeyCode.L)){
            PlayerData playerData;
            playerData = SaveSystem.Load();
            player.money = playerData.money;
            Debug.Log("Loaded");
        }
    }
}
