using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;

    public GameObject heart;
    public int heartDropRate = 5;
    public GameObject coin;
    public int coinDropRate = 30;

    private GameObject spawner;
    SpawnEnemy spawnEnemy;
    private float damagedAt;

    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;
    AudioManager am;

    Pathfinding pathfinding;

    public int health = 10;
    public int attackDmg = 1;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        am = FindObjectOfType<AudioManager>();
        spawnEnemy = spawner.GetComponent<SpawnEnemy>();
        pathfinding = GetComponent<Pathfinding>();
    }

    public void TakeDamage (int damage) {
        sr.material = matWhite;
        Invoke("ResetMaterial", .2f);
        if (health - damage <= 0) {
            Die();
        } else {
            health -= damage;
            am.Play("EnemyHit");
            damagedAt = Time.time;
            pathfinding.move = false;
        }
    }

    private void Update() {
        if (damagedAt + .1f <= Time.time)
            pathfinding.move = true;
    }

    private void Die() {
        am.Play("EnemyDeath");
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(transform.gameObject);
        SpawnEnemy.mobsKilled++;
        if (Random.Range(0, 100) < heartDropRate) {
            Instantiate(heart, transform.position, Quaternion.identity);
        }
        if (Random.Range(0, 100) < coinDropRate) {
            Instantiate(coin, transform.position, Quaternion.identity);
        }
    }

    private void ResetMaterial() {
        sr.material = matDefault;
    }
}
