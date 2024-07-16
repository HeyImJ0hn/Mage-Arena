using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int wave = 1;
    public int maxWave = 1;

    private bool started = false;
    public int balance = 0;

    AudioManager am;

    //public int activeSkin = 0;

    public Text waveText;
    public Text balanceText;

    public GameObject[] enemies;

    public GameObject achievementPopUp;

    public Player player;
    //public SkinScript skinScript;
    private Shooting shootingScript;
    public GameObject deathUI;
    public GameObject gameUI;

    public GameObject spawner;

    public float timeBetweenWaves = 2f;
    public float timeToSpawn = 2f;

    public SpawnEnemy spawnEnemy;

    public GameObject skinStore;
    public GameObject spellStore;

    public bool arena = false;

    public bool[] unlockedSpells = new bool[3];

    //public bool[] unlockedSkins = new bool[3];

    public List<Sprite> achievementImages = new List<Sprite>();
    public List<Achivements> achievements = new List<Achivements>();
    public bool[] achivBools = new bool[5];

    private void Start() {
        shootingScript = player.GetComponent<Shooting>();
        am = FindObjectOfType<AudioManager>();

        //unlockedSkins[0] = true;
        //unlockedSkins[1] = false;
        //unlockedSkins[2] = false;

        Achivements achiv1 = new Achivements("wave10", 0, false, "Survive Wave 10", achievementImages[0]);
        achievements.Add(achiv1);
        Achivements achiv2 = new Achivements("wave20", 1, false, "Surivive Wave 20", achievementImages[1]);
        achievements.Add(achiv2);
        Achivements achiv3 = new Achivements("wave1", 2, false, "Survive your first wave", achievementImages[2]);
        achievements.Add(achiv3);
        Achivements achiv4 = new Achivements("1death", 3, false, "Die for the first time", achievementImages[3]);
        achievements.Add(achiv4);
        Achivements achiv5 = new Achivements("buyspell", 4, false, "Buy your first spell", achievementImages[4]);
        achievements.Add(achiv5);
        achivBools[0] = false;
        achivBools[1] = false;
        achivBools[2] = false;
        achivBools[3] = false;
        achivBools[4] = false;

        maxWave = 1;

        player.UpdateSpells();
        LoadGame();
        balanceText.text = balance.ToString();
        if (achivBools != null) {
            UpdateAchievements();
            //skinScript.UpdateStore();
            //UpdateSkin();
        } else {
            achivBools = new bool[5];
        }
        player.UpdateSpells();
    }

    private void Update() {

        if (spellStore.activeSelf || skinStore.activeSelf) {
            shootingScript.enabled = false;
        } else {
            shootingScript.enabled = true;
        }

        if (arena) {
            if (!started) {
                StartCoroutine(spawnEnemy.SpawnEnemies(wave));
                started = true;
            }
            CheckWave();
        }

        if (player.died) {
            if (!achievements[3].getCompleted()) {
                am.Play("Achievement");
                achievements[3].SetCompleted(true);
                ChangeAchivPopUp(achievements[3]);
                ShowPopUp();
                Invoke("HidePopUp", 3f);
            }
        }
    }

    public void CheckWave() {
        if (SpawnEnemy.mobsSpawned == SpawnEnemy.mobsKilled && spawnEnemy.spawned) {
            if (wave == 1) {
                if (!achievements[2].getCompleted()) {
                    am.Play("Achievement");
                    achievements[2].SetCompleted(true);
                    ChangeAchivPopUp(achievements[2]);
                    ShowPopUp();
                    Invoke("HidePopUp", 3f);
                }
            } else if (wave == 10) {
                if (!achievements[0].getCompleted()) {
                    am.Play("Achievement");
                    achievements[0].SetCompleted(true);
                    ChangeAchivPopUp(achievements[0]);
                    ShowPopUp();
                    Invoke("HidePopUp", 3f);
                }
            } else if (wave == 20) {
                if (!achievements[1].getCompleted()) {
                    am.Play("Achievement");
                    achievements[1].SetCompleted(true);
                    ChangeAchivPopUp(achievements[1]);
                    ShowPopUp();
                    Invoke("HidePopUp", 3f);
                }
            }
            ReadySaveAchievements();
            SpawnEnemy.mobsSpawned = 0;
            SpawnEnemy.mobsKilled = 0;
            spawnEnemy.spawned = false;
            if (wave > maxWave)
                maxWave = wave;
            wave++;
            waveText.text = "WAVE " + wave.ToString();
            SaveGame();
            StartCoroutine(spawnEnemy.SpawnEnemies(wave));
        }
    }

    public void ChangeAchivPopUp(Achivements achievement) {
        achievementPopUp.transform.Find("Text").GetComponent<Text>().text = achievement.getDescription();
        achievementPopUp.transform.Find("Image").GetComponent<Image>().sprite = achievement.getImage();
    }

    public void ShowPopUp() {
        achievementPopUp.transform.LeanMoveLocal(new Vector2(-288.5f, -205.5f), 1f).setEaseOutQuart();
    }

    public void HidePopUp() {
        achievementPopUp.transform.LeanMoveLocal(new Vector2(-288.5f, -244.5f), 1f).setEaseOutQuart();
    }

    public void RestartArena() {
        wave = 1;
        arena = false;
        started = false;
        spawnEnemy.spawned = false;
        SpawnEnemy.mobsSpawned = 0;
        SpawnEnemy.mobsKilled = 0;
        waveText.text = "WAVE 1";
    }

    public void AddBalance(int amount) {
        balance += amount;
        balanceText.text = balance.ToString();
    }

    public void RemoveBalance(int amount) {
        balance -= amount;
        balanceText.text = balance.ToString();
        if (!achievements[4].getCompleted()) {
            am.Play("Achievement");
            achievements[4].SetCompleted(true);
            ChangeAchivPopUp(achievements[4]);
            ShowPopUp();
            Invoke("HidePopUp", 3f);
        }
    }

    public void ReadySaveAchievements() {
        achivBools[0] = achievements[0].getCompleted();
        achivBools[1] = achievements[1].getCompleted();
        achivBools[2] = achievements[2].getCompleted();
        achivBools[3] = achievements[3].getCompleted();
        achivBools[4] = achievements[4].getCompleted();
    }

    public void UpdateAchievements() {
        achievements[0].SetCompleted(achivBools[0]);
        achievements[1].SetCompleted(achivBools[1]);
        achievements[2].SetCompleted(achivBools[2]);
        achievements[3].SetCompleted(achivBools[3]);
        achievements[4].SetCompleted(achivBools[4]);
    }

    /*
    public void UpdateSkin() {
        player.activeSkin = activeSkin;
    }
    */

    public void SaveGame() {
        ReadySaveAchievements();
        SaveSystem.SaveGame(this);
    }

    public void LoadGame() {
        GameData data = SaveSystem.LoadGameData();
        if (data != null) { 
            balance = data.balance;
            unlockedSpells = data.unlockedSpells;
            maxWave = data.maxWave;
            //activeSkin = data.activeSkin;
            if (data.achivBools != null)
                achivBools = data.achivBools;
            //if (data.unlockedSkins != null)
            //    unlockedSkins = data.unlockedSkins;
        }
    }
}
