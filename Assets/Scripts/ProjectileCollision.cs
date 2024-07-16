using UnityEngine;
using System.Collections.Generic;

public class ProjectileCollision : MonoBehaviour
{
    public GameObject particles;
    public GameObject explosion;

    public float distance;
    public LayerMask whatIsSolid;

    Player player;

    private List<int> ids = new List<int>();

    private void Start() {
        player = FindObjectOfType<Player>();
    }

    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) {
            if (player.spells[player.activeSpell] != "fire") {
                Destroy(particles);
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
            if (hitInfo.collider.CompareTag("Enemy")) {
                if (hitInfo.collider.GetComponent<Dissolve>().dissolved && !ids.Contains(hitInfo.collider.GetInstanceID())) {
                    ids.Add(hitInfo.collider.GetInstanceID());
                    if (player.spells[player.activeSpell] == "ice")
                        hitInfo.collider.GetComponent<Pathfinding>().speed -= 2;
                    if (player.spells[player.activeSpell] == "earth" || player.spells[player.activeSpell] == "ice")
                        hitInfo.collider.GetComponent<Enemy>().TakeDamage(4);
                    else {
                        hitInfo.collider.GetComponent<Enemy>().TakeDamage(5);
                    }
                }
            } else if (hitInfo.collider.CompareTag("Dummy")) {
                hitInfo.collider.GetComponent<Dummy>().Hit();
            } else if (hitInfo.collider.CompareTag("Walls")) {
                Destroy(particles);
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
        }
    }
}
