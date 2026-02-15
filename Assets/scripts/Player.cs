using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public int money;
    public int currentMission;
    public int selectedGun;
    public int slots = 3;
    public List<PlayerGunData> guns = new List<PlayerGunData>();
}
