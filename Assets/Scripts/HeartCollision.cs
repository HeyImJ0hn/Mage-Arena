using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollision : MonoBehaviour
{
    public int healValue = 10;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Player p = collision.GetComponent<Player>();
            p.SetHealth(p.GetHealth() + healValue);
            Destroy(transform.gameObject);
        }
    }
}
