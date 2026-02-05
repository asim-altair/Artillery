using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "SO/Player")]
public class Player : ScriptableObject
{
    public int money;
    public float range;
    public float health;
    public float damage;
    public float areaDamage;
}
