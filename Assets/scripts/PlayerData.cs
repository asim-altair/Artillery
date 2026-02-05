using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class PlayerData
{
    public int money;
    public float range;
    public float health;
    public float damage;
    public float areaDamage;

    public PlayerData(Player data){
        money = data.money;
        range = data.range;
        health = data.health;
        damage = data.damage;
        areaDamage = data.areaDamage;
    }
}
