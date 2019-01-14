using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class LoaderSaver {
    public static void SaveObjectAsJSON(Armour armour) {
        string jsonPath = Application.persistentDataPath + "/data.json";
        Debug.Log("Saving to path: " + jsonPath);
        string json = JsonUtility.ToJson(armour);
        File.WriteAllText(jsonPath, json);
    }

    public static Armour LoadObjectFromJSON() {
        string jsonPath = Application.persistentDataPath + "/data.json";
        Debug.Log("Loading from path: " + jsonPath);
        if (File.Exists(jsonPath)) {
            string json = File.ReadAllText(jsonPath);
            Armour loaded = JsonUtility.FromJson<Armour>(json);
            return loaded;
        } else {
            Debug.LogError("Unable to load from file: " + jsonPath);
        }

        return null;
    }

    public static void SaveObjectAsBinary(Armour armour) {
        string binaryPath = Application.persistentDataPath + "/data.bin";

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(binaryPath, FileMode.Create);
        bf.Serialize(file, armour);
        file.Close();
    }

    public static Armour LoadObjectFromBinary() {
        string binaryPath = Application.persistentDataPath + "/data.bin";

        if (File.Exists(binaryPath)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(binaryPath, FileMode.Open);
            Armour loaded = (Armour)bf.Deserialize(file);
            file.Close();

            return loaded;
        } else {
            Debug.LogError("Unable to load from file: " + binaryPath);
        }

        return null;
    }
}
