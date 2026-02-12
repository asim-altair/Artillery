using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManger : MonoBehaviour
{
    //..........................................................SingleTon.................................................
    public static GameManger Instance;
    Player player;
    PlayerGunData playerGunData;
    public bool playerTurn = true;
    public GunData[] allGuns;
    void Awake(){
    //..........................................................SingleTon.................................................
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
            player = SaveSystem.Load();
            if(player == null){
                player = new Player();
                player.money = 0;
                player.currentMission = 1;
                foreach(GunData singleGun in allGuns){
                    playerGunData = new PlayerGunData();
                    playerGunData.id = singleGun.id;
                    playerGunData.gunName = singleGun.gunName;
                    playerGunData.health = singleGun.health;
                    playerGunData.range = singleGun.range;
                    playerGunData.damage = singleGun.damage;
                    playerGunData.areaDamage = singleGun.areaDamage;
                    playerGunData.locked = singleGun.locked;
                    player.guns.Add(playerGunData);
                }
            }else{
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

                        player.guns.Add(newGun);
                    }
                }
            }
        }else{
            Destroy(gameObject);
            return;
        }
    }

    void Start(){
        Debug.Log(player.money);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.S)){
            SaveSystem.Save(player);
        }
    }
}
