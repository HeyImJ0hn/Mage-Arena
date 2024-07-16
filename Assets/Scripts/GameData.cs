using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int balance { get; set; }
    //public int activeSkin { get; set; }
    public int maxWave { get; set; }
    public bool[] unlockedSpells { get; set; }
    public bool[] achivBools { get; set; }
    //public bool[] unlockedSkins { get; set; }

    public GameData(GameManager gm) {
        balance = gm.balance;
        //activeSkin = gm.activeSkin;
        maxWave = gm.maxWave;

        unlockedSpells = new bool[3];
        unlockedSpells[0] = gm.unlockedSpells[0];
        unlockedSpells[1] = gm.unlockedSpells[1];
        unlockedSpells[2] = gm.unlockedSpells[2];

        achivBools = new bool[5];
        achivBools[0] = gm.achivBools[0];
        achivBools[1] = gm.achivBools[1];
        achivBools[2] = gm.achivBools[2];
        achivBools[3] = gm.achivBools[3];
        achivBools[4] = gm.achivBools[4];

        /*
        unlockedSkins = new bool[3];
        unlockedSkins[0] = gm.unlockedSkins[0];
        unlockedSkins[1] = gm.unlockedSkins[1];
        unlockedSkins[2] = gm.unlockedSkins[2];*/
    }

    public override string ToString() {
        return "Balance: " + balance + " | achivBools[0]: " 
            + achivBools[0] + " | achivBools[1]: " + achivBools[1] 
            + "\nunlockedSpells[0]: " + unlockedSpells[0] + " | unlockedSpells[1]: " + unlockedSpells[1] + " | unlockedSpells[2]: " + unlockedSpells[2];
    }
}
