using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;




public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/data.x";
    private static BinaryFormatter formatter = new BinaryFormatter();

    public static void Save(Player gameManger){
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData playerData = new PlayerData(gameManger);
        formatter.Serialize(stream, playerData);
        stream.Close();
    }
    public static PlayerData Load(){
        if(File.Exists(path)){
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return playerData;
        }else{
            return null;
        }
    }
}
