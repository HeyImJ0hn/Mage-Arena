using UnityEngine;
using UnityEngine.UI;
using System;

public class CoinCollider : MonoBehaviour
{
    GameManager gm;
    AudioManager am;
    private void Start() {
        gm = FindObjectOfType<GameManager>();
        am = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            am.Play("Coin");
            gm.AddBalance(1);
            Destroy(transform.gameObject);
        }
    }
}
