using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject shopNPC;
    public GameObject player;
    public Button btnFire;
    public Button btnIce;
    public Button btnEarth;
    public GameObject shopUI;

    GameManager gm;

    private SpriteRenderer sr;
    private Sprite defaultSprite;
    public Sprite selectedSprite;

    private bool isOpen = false;

    private int spellPrice = 50;


    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        sr = shopNPC.GetComponent<SpriteRenderer>();
        defaultSprite = sr.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, shopNPC.transform.position) < 2) {
            sr.sprite = selectedSprite;
            if (Input.GetKeyDown(KeyCode.E) && !isOpen) {
                isOpen = true;
                shopUI.SetActive(true);
                //player.GetComponent<Shooting>().enabled = false;
            } else if (Input.GetKeyDown(KeyCode.E) && isOpen) {
                isOpen = false;
                shopUI.SetActive(false);
                //player.GetComponent<Shooting>().enabled = true;
            }
        } else {
            sr.sprite = defaultSprite;
            isOpen = false;
            shopUI.SetActive(false);
            //player.GetComponent<Shooting>().enabled = true;
        }

        if (isOpen) {
            if (gm.balance >= spellPrice) {
                if (gm.unlockedSpells[0]) {
                    btnFire.interactable = false;
                } 
                if (gm.unlockedSpells[1]) {
                    btnIce.interactable = false;
                }
                if (gm.unlockedSpells[2]) {
                    btnEarth.interactable = false;
                }
            } else {
                btnFire.interactable = false;
                btnIce.interactable = false;
                btnEarth.interactable = false;
            }
        }
    }

    public void PurchaseItem(string item) {
        switch (item) {
            case "fire":
                gm.unlockedSpells[0] = true;
                gm.RemoveBalance(spellPrice);
                break;
            case "ice":
                gm.unlockedSpells[1] = true;
                gm.RemoveBalance(spellPrice);
                break;
            case "earth":
                gm.unlockedSpells[2] = true;
                gm.RemoveBalance(spellPrice);
                break;
        }
        player.GetComponent<Player>().UpdateSpells();
        gm.SaveGame();
    }
}
