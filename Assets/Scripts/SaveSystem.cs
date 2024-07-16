using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    
    public static void SaveGame(GameManager gameManager) {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/game.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGameData() {
        string path = Application.persistentDataPath + "/game.data";
        FileStream stream;
        try { 
            stream = new FileStream(path, FileMode.Open);
        } 
        catch {
            stream = new FileStream(path, FileMode.Create);
        }
        if (File.Exists(path) && stream.Length > 0) {
            BinaryFormatter formatter = new BinaryFormatter();
            
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        } else {
            Debug.Log("Save file not found in " + path);
            stream.Close();
            return null;
        }
    }

}
