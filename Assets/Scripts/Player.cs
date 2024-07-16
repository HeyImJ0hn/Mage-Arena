using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    public int maxHealth = 100;
    private int health;

    private float deathTime = 2f;

    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;

    [HideInInspector]
    public bool died = false;
    private float diedAt;

    public GameObject gameUI;
    public GameObject deathUI;

    public Text spellText;

    public SpawnEnemy spawnEnemy;

    Animator animator;
    PlayerMovement pm;

    AudioManager am;

    public HealthBar healthBar;

    public GameManager gm;

    public bool god = false;

    public List<string> spells = new List<string>();
    public int activeSpell = 0;

    //public Sprite[] availableSkins = new Sprite[3];
    //public int activeSkin = 0;

    //private ChangeSkin changeSkin;

    private void Start() {
        //changeSkin = GetComponent<ChangeSkin>();
        animator = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        am = FindObjectOfType<AudioManager>();
        sr = GetComponent<SpriteRenderer>();

        switch (spells[activeSpell]) {
            case "wind":
                spellText.text = "Wind Strike";
                break;
            case "fire":
                spellText.text = "Fire Strike";
                break;
            case "ice":
                spellText.text = "Ice Bolt";
                break;
            case "earth":
                spellText.text = "Earth Blast";
                break;
        }
        //UpdateSkin();
        health = maxHealth;
        healthBar.SetHealth(maxHealth);
        //activeSkin = gm.activeSkin;
        
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    public void TakeDamage(int damage) {
        if (!god) {
            if (!died) {
                am.Play("Hit");
                sr.material = matWhite;
                Invoke("ResetMaterial", .2f);
                health -= damage;
                healthBar.SetHealth(health);
            }
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            ChangeSpell(100);
        } else if (Input.GetKeyDown(KeyCode.Alpha1)) {
            ChangeSpell(0);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            ChangeSpell(1);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            ChangeSpell(2);
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            ChangeSpell(3);
        }

        if (health <= 0) {
            if (!died) {
                diedAt = Time.time;
            }
            GetComponent<Shooting>().enabled = false;
            died = true;
            spawnEnemy.enabled = false;
            animator.SetTrigger("Death");
            pm.enabled = false;
            if (diedAt + deathTime <= Time.time) {
                gameUI.SetActive(false);
                deathUI.SetActive(true);
            }
            gm.SaveGame();
        }
    }

    private void ResetMaterial() {
        sr.material = matDefault;
    }

    public void SetHealth(int health) {
        if (this.health + health > maxHealth)
            this.health = maxHealth;
        else
            this.health = health;
        healthBar.SetHealth(health);
    }

    public int GetHealth() {
        return health;
    }

    public void ChangeSpell(int index) {
        switch (index) {
            case 0:
                activeSpell = 0;
                break;
            case 1:
                activeSpell = 1;
                break;
            case 2:
                activeSpell = 2;
                break;
            case 3:
                activeSpell = 3;
                break;
            default:
                activeSpell += 1;
                break;
        }
        if (activeSpell >= spells.Count)
            activeSpell = 0;
        switch (spells[activeSpell]) {
            case "wind":
                spellText.text = "Wind Strike";
                break;
            case "fire":
                spellText.text = "Fire Strike";
                break;
            case "ice":
                spellText.text = "Ice Bolt";
                break;
            case "earth":
                spellText.text = "Earth Blast";
                break;
        }
    }

    public void UpdateSpells() {
        spells = new List<string>();
        spells.Add("wind");
        for (int i = 0; i < gm.unlockedSpells.Length; i++) {
            if (gm.unlockedSpells[i]) {
                switch (i) {
                    case 0:
                        spells.Add("fire");
                        break;
                    case 1:
                        spells.Add("ice");
                        break;
                    case 2:
                        spells.Add("earth");
                        break;
                }
            }
        }
    }

    /*
    public void UpdateSkin() {
        if (activeSkin == 0) {
            sr.sprite = availableSkins[0];
            changeSkin.DefaultSkin();
        } else if (activeSkin == 1) { 
            sr.sprite = availableSkins[1];
            changeSkin.PurpleSkin();
        } else if (activeSkin == 2) {
            sr.sprite = availableSkins[2];
            changeSkin.RedSkin();
        }
        gm.SaveGame();
    }
    */
}
