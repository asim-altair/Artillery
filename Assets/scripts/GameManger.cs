using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManger : MonoBehaviour
{
    //..........................................................SingleTon.................................................
    public static GameManger Instance;
    public Player player;
    PlayerGunData playerGunData;
    public bool playerTurn = true;
    public GunData[] allGuns;
    void Awake(){
    //..........................................................SingleTon.................................................
        if(Instance == null){
            Instance = this;
            // DontDestroyOnLoad(gameObject);
            player = SaveSystem.Load();
    //.......................................................Loading first Time...........................................
            if(player == null){
                player = new Player();
                player.money = 0;
                player.currentMission = 1;
                player.selectedGun = 0;
                player.slots = 1;
                foreach(GunData singleGun in allGuns){
                    playerGunData = new PlayerGunData();
                    playerGunData.id = singleGun.id;
                    playerGunData.gunName = singleGun.gunName;
                    playerGunData.health = singleGun.health;
                    playerGunData.range = singleGun.range;
                    playerGunData.damage = singleGun.damage;
                    playerGunData.areaDamage = singleGun.areaDamage;
                    playerGunData.locked = singleGun.locked;
                    playerGunData.healthLevel = 1;
                    playerGunData.rangeLevel = 1;
                    playerGunData.damageLevel = 1;
                    playerGunData.areaDamageLevel = 1;
                    player.guns.Add(playerGunData);
                }
            }else{
    //.....................................................Adding new guns if added to project............................
                if(player.guns == null){
                    player.guns = new List<PlayerGunData>();
                }
                foreach(GunData gunData in allGuns){
                    bool gunExists = false;
                    foreach(PlayerGunData savedGun in player.guns){
                        if(savedGun.id == gunData.id){
                            gunExists = true;
                            break;
                        }
                    }

                    if(!gunExists){
                        Debug.Log("Adding Guns" + gunData.gunName);
                        PlayerGunData newGun = new PlayerGunData();
                        newGun.id = gunData.id;
                        newGun.gunName = gunData.gunName;
                        newGun.health = gunData.health;
                        newGun.range = gunData.range;
                        newGun.damage = gunData.damage;
                        newGun.areaDamage = gunData.areaDamage;
                        newGun.locked = gunData.locked;
                        newGun.healthLevel = 0;
                        newGun.rangeLevel = 0;
                        newGun.damageLevel = 0;
                        newGun.areaDamageLevel = 0;

                        player.guns.Add(newGun);
                    }
                }
            }
        }else{
            Destroy(gameObject);
            return;
        }
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.S)){
            SaveSystem.Save(player);
        }
    }
}
