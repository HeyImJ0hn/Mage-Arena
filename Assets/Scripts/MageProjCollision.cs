using UnityEngine;

public class MageProjCollision : MonoBehaviour {
    public GameObject particles;
    public GameObject explosion;

    public float distance;
    public LayerMask whatIsSolid;

    Player player;
    public Enemy enemy;

    private void Start() {
        player = FindObjectOfType<Player>();
    }

    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Player")) {
                player.TakeDamage(enemy.attackDmg);
                Destroy(particles);
                Instantiate(explosion, transform.position, Quaternion.identity);
            } else if (!hitInfo.collider.CompareTag("Enemy")) {
                Destroy(particles);
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
        }
    }
}
