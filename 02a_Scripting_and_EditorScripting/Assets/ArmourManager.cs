using UnityEngine;
using System.IO;

[System.Serializable]
public class ArmourManager : MonoBehaviour {
    public string chest = "none";
    public string legs = "none";
    public string helmet = "none";

    public bool saveAsJSON = true;

    private string jsonPath;

    private void Awake() {
        Debug.Log("Set path: " + jsonPath);
        jsonPath = Application.persistentDataPath + "/data.json";
    }

    [ContextMenu("Save")]
    void Save() {
        if (saveAsJSON) {
            LoaderSaver.SaveObjectAsJSON(new Armour(this));
        } else {
            LoaderSaver.SaveObjectAsBinary(new Armour(this));
        }
    }

    [ContextMenu("Load")]
    void Load() {
        if (saveAsJSON) {
            Armour loaded = LoaderSaver.LoadObjectFromJSON();
            this.chest = loaded.chest;
            this.legs = loaded.legs;
            this.helmet = loaded.helmet;
        } else {
            Armour loaded = LoaderSaver.LoadObjectFromBinary();
            this.chest = loaded.chest;
            this.legs = loaded.legs;
            this.helmet = loaded.helmet;
        }
    }
}
