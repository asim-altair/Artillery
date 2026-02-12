using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static void Save(Player player){
        string path = Application.persistentDataPath + "/tairifyData.json";
        string data = JsonUtility.ToJson(player, true);
        File.WriteAllText(path, data);
        Debug.Log("Saved at: " + path);
    }

    public static Player Load(){
        string path = Application.persistentDataPath + "/tairifyData.json";
        if(File.Exists(path)){
            string data = File.ReadAllText(path);
            Player player = JsonUtility.FromJson<Player>(data);
            return player;
        }else{
            return null;
        }
    }
}
