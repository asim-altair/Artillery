using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName  = "Gun", menuName = "SOs/gun")]
public class GunData : ScriptableObject
{
    public int id;
    public string gunName;
    public int price;
    public float health;
    public float range;
    public float damage;
    public float areaDamage;
    public bool locked;
}
