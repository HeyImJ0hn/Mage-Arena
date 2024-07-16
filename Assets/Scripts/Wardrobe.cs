using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite selectedSprite;
    private Sprite defaultSprite;
    public GameObject wardrobe;
    public GameObject player;
    public GameObject wardrobeUI;

    // Start is called before the first frame update
    void Start()
    {
        sr = wardrobe.GetComponent<SpriteRenderer>();
        defaultSprite = sr.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, wardrobe.transform.position) < 2) {
            sr.sprite = selectedSprite;
            wardrobeUI.SetActive(true);
        } else {
            sr.sprite = defaultSprite;
            wardrobeUI.SetActive(false);
        }
    }
}
