using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveGame
{
    public static void SavePlayer(CarController car , LevelManager levelmanager, GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream streem = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(levelmanager,car,gameManager);
        formatter.Serialize(streem,data);
        streem.Close();

    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
