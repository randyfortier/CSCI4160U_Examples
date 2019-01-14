using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Armour {
    public string chest = "none";
    public string legs = "none";
    public string helmet = "none";

    public Armour(ArmourManager source) {
        this.chest = source.chest;
        this.legs = source.legs;
        this.helmet = source.helmet;
    }

    public Armour(string chest, string legs, string helmet) {
        this.chest = chest;
        this.legs = legs;
        this.helmet = helmet;
    }
}
